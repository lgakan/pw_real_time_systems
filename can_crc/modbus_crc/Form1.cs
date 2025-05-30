using System.Diagnostics;

namespace modbus_crc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnCalculateCrc_Click(object sender, EventArgs e)
        {
            string inputBin = TxtBinInput.Text.Trim();

            if (inputBin.Length == 0 || inputBin.Length > 96)
            {
                MessageBox.Show("WprowadŸ od 1 do 96 bitów w formacie bin", "B³¹d danych");
                return;
            }

            byte[] data = GetBitByteArray(inputBin);

            if (!long.TryParse(TxtInputIterations.Text.Trim(), out long iterations) || iterations < 1 || iterations > 1_000_000_000)
            {
                MessageBox.Show("Podaj poprawn¹ liczbê iteracji (1..1 000 000 000).", "B³¹d danych");
                return;
            }

            Stopwatch sw = Stopwatch.StartNew();
            string crc = "";
            for (long i = 0; i < iterations; i++)
            {
                crc = CalculateCRC(data).ToString("X4");
            }
            sw.Stop();

            TxtOutputCrc.Text = crc;
            TimeSpan duration = sw.Elapsed;
            double totalMs = duration.TotalMilliseconds;
            double avgMs = totalMs / iterations;
            TxtSumTime.Text = FormatTime(totalMs);
            TxtAverageTime.Text = FormatTime(avgMs);
        }

        private static UInt16 CalculateCRC(byte[] data)
        {
            UInt16 crc = 0;
            foreach (byte current in data)
            {
                crc ^= (UInt16)(current << 7);
                for (int i = 0; i < 8; i++)
                {
                    crc <<= 1;
                    if ((crc & 0x8000) != 0)
                    {
                        crc ^= 0x4599;
                    }
                }
                crc &= 0x7fff;
            }
            return crc;
        }

        private static byte[] GetBitByteArray(string input)
        {
            List<byte> byteList = new List<byte>();
            for (int i = input.Length - 1; i >= 0; i -= 8)
            {
                string byteString = "";
                for (int j = 0; (i - j) >= 0 && j < 8; j++)
                {
                    byteString = input[i - j] + byteString;
                }
                if (byteString != "")
                {
                    byteList.Add(Convert.ToByte(byteString, 2));
                }
            }
            byteList.Reverse();
            return byteList.ToArray();
        }


        private static string FormatTime(double timeMs)
        {
            if (timeMs >= 1)
                return $"{timeMs:N3} ms";
            else if (timeMs >= 0.001)
                return $"{timeMs * 1000:N3} µs";
            else
                return $"{timeMs * 1_000_000:N3} ns";
        }
    }
}