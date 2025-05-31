namespace hart_ieee_float
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            string inputHex = TxtInput.Text.Trim().Replace(" ", "").ToUpper();

            if (string.IsNullOrEmpty(inputHex) || inputHex.Length != 8 || !inputHex.All(c => Uri.IsHexDigit(c)))
            {
                MessageBox.Show("Wprowadz dokladnie 8 cyfr szesnastkowych (0-9, A-F).", "Blad danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string output;
            try
            {
                if (RbtnToIEEE.Checked)
                {
                    output = InternalToIEEE754(inputHex);
                }
                else if (RbtnToInternal.Checked)
                {
                    output = IEEE754ToInternal(inputHex);
                }
                else
                {
                    MessageBox.Show("Wybierz kierunek konwersji.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                TxtOutput.Text = output;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Blad konwersji: {ex.Message}", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string InternalToIEEE754(string internalHex)
        {
            // 1) Strip spaces, parse into a 32‑bit unsigned int (big‑endian).
            string h = internalHex.Replace(" ", "").Replace(" ", "").Trim();
            if (h.Length != 8)
                throw new ArgumentException("Wprowadzona wartosc musi byc liczba hex skladajacaca sie z 8 znakow (moze zawierac spacje).");

            if (!UInt32.TryParse(h,
                                 System.Globalization.NumberStyles.HexNumber,
                                 System.Globalization.CultureInfo.InvariantCulture,
                                 out uint internalWord))
            {
                throw new ArgumentException("Wprowadzona wartosc nie jest poprawna liczba hex.");
            }

            // 2) If the entire 32 bits == 0, that represents float zero.
            if (internalWord == 0u)
            {
                return "00 00 00 00";
            }

            // 3) Extract bit31.  It should be 1 for any non‑zero value.
            //    If bit31==0 but the word ≠ 0, that is not a valid encoding.
            bool topBit = ((internalWord >> 31) & 0x1) == 1;
            if (!topBit)
                throw new ArgumentException("MSB musi byc 1 dla nie zerowych wartosci.");

            // 4) Extract the unbiased exponent E = bits30–24.
            int E = (int)((internalWord >> 24) & 0x7Fu);

            // 5) Extract the 16‑bit fraction-field F = bits23–8.
            int F16 = (int)((internalWord >> 8) & 0xFFFFu);

            // 6) Reconstruct the real‑valued float:
            //       value = (1 + F16/2^15) * 2^E
            //    Note: F16/2^15 is exactly a float in [0, 1.9999…], so it's safe to do
            //          everything in System.Single (float).
            float fraction = F16 / 32768.0f;   // i.e. 2^15 = 32768
            float realVal = (1.0f + fraction) * MathF.Pow(2.0f, E);

            // 7) Convert that C# float → IEEE bits (uint) via SingleToUInt32Bits.
            uint ieeeBits = BitConverter.SingleToUInt32Bits(realVal);

            // 8) Format as big‑endian hex with spaces:
            byte b0 = (byte)((ieeeBits >> 24) & 0xFF);
            byte b1 = (byte)((ieeeBits >> 16) & 0xFF);
            byte b2 = (byte)((ieeeBits >> 8) & 0xFF);
            byte b3 = (byte)(ieeeBits & 0xFF);

            return $"{b0:X2}{b1:X2} {b2:X2}{b3:X2}";
        }
        public static string IEEE754ToInternal(string ieeeHex)
        {
            // 1) Strip spaces, parse into a 32‑bit unsigned int
            string h = ieeeHex.Replace(" ", "").Replace(" ", "").Trim();
            if (h.Length != 8)
                throw new ArgumentException("IEEE754 hex musi byc dokladnie 8 znakami (spacje dozwolone).");

            if (!UInt32.TryParse(h,
                                 System.Globalization.NumberStyles.HexNumber,
                                 System.Globalization.CultureInfo.InvariantCulture,
                                 out uint ieeeWord))
            {
                throw new ArgumentException("IEEE754 hex string nie jest poprawnym hexem.");
            }

            // 2) Decompose IEEE bits:
            //    bit31 = sign, bits30–23 = biased exponent, bits22–0 = mantissa.
            bool signBit = ((ieeeWord >> 31) & 0x1) == 1;
            uint biasedExp = (ieeeWord >> 23) & 0xFFu;
            uint mantissa23 = ieeeWord & 0x7FFFFFu;  // lower 23 bits

            // 3) If everything == 0 (i.e. +0.0), output internal = 0x00000000
            if (!signBit && biasedExp == 0u && mantissa23 == 0u)
            {
                return "00 00 00 00";
            }

            // 4) We only support NON‑NEGATIVE floats here (no sign).  If signBit==1, throw.
            if (signBit)
                throw new ArgumentException("Ujemne IEEE754 wartosci nie sa obslugiwane w tej apliacji dla kodu wewnetrznego.");

            // 5) If biasedExp == 0 but mantissa23 !=0 => subnormal.  In HART internal we cannot represent
            //    subnormals, so treat them as zero (or optionally throw).  We'll map to 0.0.
            if (biasedExp == 0u)
            {
                // For simplicity, treat as zero:
                return "00 00 00 00";
            }

            // 6) Compute the unbiased exponent:
            int E = (int)biasedExp - 127;   // IEEE bias=127

            if (E < 0 || E > 127)
            {
                // HART internal only has a 7‑bit exponent field (0..127).  If outside that range, clamp or throw:
                throw new ArgumentException($"Wartosc poza zakresem E = {E}.");
            }

            // 7) In IEEE, normalized value = (1 + mantissa23/2^23) * 2^E.
            //    To build internal, we need F16 = Round[ ( (1 + mant23/2^23) - 1 ) * 2^15 ]
            //                     i.e. F16 = Round( (mant23/2^23) * 2^15 )
            //           = Round( mant23 / 2^8 ).
            //    We'll do nearest‑even rounding by adding 0x80 before shifting.
            uint temp = mantissa23 + 0x80u;            // add 128 to bias for nearest
            uint F16 = (temp >> 8) & 0xFFFFu;         // keep only top 16 bits

            if (F16 > 0xFFFFu)
                F16 = 0xFFFFu;  // clamp just in case rounding overflowed

            // 8) Build the 32‑bit internal word:
            //      bit31 = 1
            //      bits30–24 = E (7 bits)
            //      bits23–8  = F16 (16 bits)
            //      bits7–0   = 0
            uint internalWord = (1u << 31)
                              | ((uint)E << 24)
                              | (F16 << 8);

            // 9) Format as big‑endian hex with spaces:
            byte b0 = (byte)((internalWord >> 24) & 0xFF);
            byte b1 = (byte)((internalWord >> 16) & 0xFF);
            byte b2 = (byte)((internalWord >> 8) & 0xFF);
            byte b3 = (byte)(internalWord & 0xFF);
            return $"{b0:X2}{b1:X2} {b2:X2}{b3:X2}";
        }
    }
}