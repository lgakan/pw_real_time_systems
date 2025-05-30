namespace modbus_crc
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnCalculateCrc = new Button();
            TxtBytesInput = new TextBox();
            TxtInputIterations = new TextBox();
            label1 = new Label();
            label2 = new Label();
            TxtOutputCrc = new TextBox();
            label3 = new Label();
            label4 = new Label();
            TxtSumTime = new TextBox();
            label5 = new Label();
            TxtAverageTime = new TextBox();
            SuspendLayout();
            // 
            // BtnCalculateCrc
            // 
            BtnCalculateCrc.Location = new Point(336, 163);
            BtnCalculateCrc.Name = "BtnCalculateCrc";
            BtnCalculateCrc.Size = new Size(100, 32);
            BtnCalculateCrc.TabIndex = 0;
            BtnCalculateCrc.Text = "Oblicz CRC";
            BtnCalculateCrc.UseVisualStyleBackColor = true;
            BtnCalculateCrc.Click += BtnCalculateCrc_Click;
            // 
            // TxtBytesInput
            // 
            TxtBytesInput.Location = new Point(209, 39);
            TxtBytesInput.Name = "TxtBytesInput";
            TxtBytesInput.Size = new Size(379, 23);
            TxtBytesInput.TabIndex = 1;
            // 
            // TxtInputIterations
            // 
            TxtInputIterations.Location = new Point(209, 112);
            TxtInputIterations.Name = "TxtInputIterations";
            TxtInputIterations.Size = new Size(379, 23);
            TxtInputIterations.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(209, 94);
            label1.Name = "label1";
            label1.Size = new Size(139, 15);
            label1.TabIndex = 3;
            label1.Text = "Liczba iteracji algorytmu:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(209, 21);
            label2.Name = "label2";
            label2.Size = new Size(194, 15);
            label2.TabIndex = 4;
            label2.Text = "Wejściowa sekwencja bajtów [hex]: ";
            // 
            // TxtOutputCrc
            // 
            TxtOutputCrc.Location = new Point(209, 233);
            TxtOutputCrc.Name = "TxtOutputCrc";
            TxtOutputCrc.ReadOnly = true;
            TxtOutputCrc.Size = new Size(379, 23);
            TxtOutputCrc.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(209, 215);
            label3.Name = "label3";
            label3.Size = new Size(166, 15);
            label3.TabIndex = 6;
            label3.Text = "Wartość wyliczonej CRC [hex]:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(209, 282);
            label4.Name = "label4";
            label4.Size = new Size(118, 15);
            label4.TabIndex = 8;
            label4.Text = "Łączny czas obliczeń:";
            // 
            // TxtSumTime
            // 
            TxtSumTime.Location = new Point(209, 300);
            TxtSumTime.Name = "TxtSumTime";
            TxtSumTime.ReadOnly = true;
            TxtSumTime.Size = new Size(379, 23);
            TxtSumTime.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(209, 347);
            label5.Name = "label5";
            label5.Size = new Size(106, 15);
            label5.TabIndex = 10;
            label5.Text = "Średni czas iteracji:";
            // 
            // TxtAverageTime
            // 
            TxtAverageTime.Location = new Point(209, 365);
            TxtAverageTime.Name = "TxtAverageTime";
            TxtAverageTime.ReadOnly = true;
            TxtAverageTime.Size = new Size(379, 23);
            TxtAverageTime.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(TxtAverageTime);
            Controls.Add(label4);
            Controls.Add(TxtSumTime);
            Controls.Add(label3);
            Controls.Add(TxtOutputCrc);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TxtInputIterations);
            Controls.Add(TxtBytesInput);
            Controls.Add(BtnCalculateCrc);
            Name = "Form1";
            Text = "Kalkulator CRC - Modbus";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnCalculateCrc;
        private TextBox TxtBytesInput;
        private TextBox TxtInputIterations;
        private Label label1;
        private Label label2;
        private TextBox TxtOutputCrc;
        private Label label3;
        private Label label4;
        private TextBox TxtSumTime;
        private Label label5;
        private TextBox TxtAverageTime;
    }
}