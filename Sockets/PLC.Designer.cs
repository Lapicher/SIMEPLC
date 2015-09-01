namespace Sockets
{
    partial class PLC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.rBtnA = new System.Windows.Forms.RadioButton();
            this.rBtnM = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxE = new System.Windows.Forms.ComboBox();
            this.cboxL = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Iniciar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rBtnA
            // 
            this.rBtnA.AutoSize = true;
            this.rBtnA.Location = new System.Drawing.Point(223, 149);
            this.rBtnA.Name = "rBtnA";
            this.rBtnA.Size = new System.Drawing.Size(78, 17);
            this.rBtnA.TabIndex = 12;
            this.rBtnA.TabStop = true;
            this.rBtnA.Text = "Automático";
            this.rBtnA.UseVisualStyleBackColor = true;
            // 
            // rBtnM
            // 
            this.rBtnM.AutoSize = true;
            this.rBtnM.Location = new System.Drawing.Point(110, 149);
            this.rBtnM.Name = "rBtnM";
            this.rBtnM.Size = new System.Drawing.Size(60, 17);
            this.rBtnM.TabIndex = 11;
            this.rBtnM.TabStop = true;
            this.rBtnM.Text = "Manual";
            this.rBtnM.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Estación: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Línea: ";
            // 
            // cboxE
            // 
            this.cboxE.FormattingEnabled = true;
            this.cboxE.Location = new System.Drawing.Point(171, 90);
            this.cboxE.Name = "cboxE";
            this.cboxE.Size = new System.Drawing.Size(152, 21);
            this.cboxE.TabIndex = 8;
            // 
            // cboxL
            // 
            this.cboxL.FormattingEnabled = true;
            this.cboxL.Location = new System.Drawing.Point(171, 38);
            this.cboxL.Name = "cboxL";
            this.cboxL.Size = new System.Drawing.Size(152, 21);
            this.cboxL.TabIndex = 7;
            this.cboxL.TextChanged += new System.EventHandler(this.cboxL_TextChanged);
            // 
            // PLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rBtnA);
            this.Controls.Add(this.rBtnM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxE);
            this.Controls.Add(this.cboxL);
            this.Name = "PLC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLC";
            this.Load += new System.EventHandler(this.PLC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rBtnA;
        private System.Windows.Forms.RadioButton rBtnM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxL;
        public System.Windows.Forms.ComboBox cboxE;
    }
}