namespace Diablo2Tools
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
            runCounter = new NumericUpDown();
            labelCounter = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)runCounter).BeginInit();
            SuspendLayout();
            // 
            // runCounter
            // 
            runCounter.Location = new Point(210, 191);
            runCounter.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            runCounter.Name = "runCounter";
            runCounter.Size = new Size(120, 23);
            runCounter.TabIndex = 0;
            // 
            // labelCounter
            // 
            labelCounter.AutoSize = true;
            labelCounter.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCounter.ForeColor = Color.Yellow;
            labelCounter.Location = new Point(53, 32);
            labelCounter.Name = "labelCounter";
            labelCounter.Size = new Size(19, 21);
            labelCounter.TabIndex = 2;
            labelCounter.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(40, 21);
            label1.TabIndex = 3;
            label1.Text = "run:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 279);
            Controls.Add(label1);
            Controls.Add(labelCounter);
            Controls.Add(runCounter);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)runCounter).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown runCounter;
        private Label labelCounter;
        private Label label1;
    }
}
