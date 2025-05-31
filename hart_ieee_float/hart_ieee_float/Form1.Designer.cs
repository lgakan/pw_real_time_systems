namespace hart_ieee_float
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
            TxtInput = new TextBox();
            label1 = new Label();
            RbtnToIEEE = new RadioButton();
            RbtnToInternal = new RadioButton();
            Group_pick = new GroupBox();
            label2 = new Label();
            TxtOutput = new TextBox();
            BtnCalculate = new Button();
            Group_pick.SuspendLayout();
            SuspendLayout();
            // 
            // TxtInput
            // 
            TxtInput.Location = new Point(66, 44);
            TxtInput.Name = "TxtInput";
            TxtInput.Size = new Size(393, 23);
            TxtInput.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 26);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 1;
            label1.Text = "Wejscie [hex]";
            // 
            // RbtnToIEEE
            // 
            RbtnToIEEE.AutoSize = true;
            RbtnToIEEE.Location = new Point(6, 22);
            RbtnToIEEE.Name = "RbtnToIEEE";
            RbtnToIEEE.Size = new Size(126, 19);
            RbtnToIEEE.TabIndex = 2;
            RbtnToIEEE.TabStop = true;
            RbtnToIEEE.Text = "Internal -> IEEE 754";
            RbtnToIEEE.UseVisualStyleBackColor = true;
            // 
            // RbtnToInternal
            // 
            RbtnToInternal.AutoSize = true;
            RbtnToInternal.Location = new Point(6, 60);
            RbtnToInternal.Name = "RbtnToInternal";
            RbtnToInternal.Size = new Size(129, 19);
            RbtnToInternal.TabIndex = 3;
            RbtnToInternal.TabStop = true;
            RbtnToInternal.Text = "IEEE 754 -> Internal ";
            RbtnToInternal.UseVisualStyleBackColor = true;
            // 
            // Group_pick
            // 
            Group_pick.Controls.Add(RbtnToInternal);
            Group_pick.Controls.Add(RbtnToIEEE);
            Group_pick.Location = new Point(164, 83);
            Group_pick.Name = "Group_pick";
            Group_pick.Size = new Size(213, 106);
            Group_pick.TabIndex = 4;
            Group_pick.TabStop = false;
            Group_pick.Text = "Wybierz strone";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 265);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 5;
            label2.Text = "Wyjscie [hex]";
            // 
            // TxtOutput
            // 
            TxtOutput.Location = new Point(66, 283);
            TxtOutput.Name = "TxtOutput";
            TxtOutput.ReadOnly = true;
            TxtOutput.Size = new Size(393, 23);
            TxtOutput.TabIndex = 6;
            // 
            // BtnCalculate
            // 
            BtnCalculate.Location = new Point(210, 212);
            BtnCalculate.Name = "BtnCalculate";
            BtnCalculate.Size = new Size(100, 35);
            BtnCalculate.TabIndex = 7;
            BtnCalculate.Text = "Konwertuj";
            BtnCalculate.UseVisualStyleBackColor = true;
            BtnCalculate.Click += BtnCalculate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 318);
            Controls.Add(BtnCalculate);
            Controls.Add(TxtOutput);
            Controls.Add(label2);
            Controls.Add(Group_pick);
            Controls.Add(label1);
            Controls.Add(TxtInput);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Konwerter IEEE754 - Internal";
            Group_pick.ResumeLayout(false);
            Group_pick.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtInput;
        private Label label1;
        private RadioButton RbtnToIEEE;
        private RadioButton RbtnToInternal;
        private GroupBox Group_pick;
        private Label label2;
        private TextBox TxtOutput;
        private Button BtnCalculate;
    }
}