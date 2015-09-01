namespace Sockets
{
    partial class Automatico
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnl_variables = new System.Windows.Forms.Panel();
            this.lb_programas = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lb_folio = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dg_procesados = new System.Windows.Forms.DataGridView();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lst_folios = new System.Windows.Forms.ListBox();
            this.txt_tiempo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.btn_iniciar = new System.Windows.Forms.Button();
            this.btn_terminar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_abrir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_procesados)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo2D:";
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(100, 36);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(100, 20);
            this.txt_codigo.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnl_variables);
            this.groupBox1.Location = new System.Drawing.Point(26, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 332);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Variables enviadas por PLC";
            // 
            // pnl_variables
            // 
            this.pnl_variables.AutoScroll = true;
            this.pnl_variables.AutoScrollMargin = new System.Drawing.Size(75, 175);
            this.pnl_variables.AutoScrollMinSize = new System.Drawing.Size(50, 75);
            this.pnl_variables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_variables.Location = new System.Drawing.Point(3, 16);
            this.pnl_variables.Name = "pnl_variables";
            this.pnl_variables.Size = new System.Drawing.Size(311, 313);
            this.pnl_variables.TabIndex = 0;
            // 
            // lb_programas
            // 
            this.lb_programas.AutoSize = true;
            this.lb_programas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_programas.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_programas.Location = new System.Drawing.Point(980, 13);
            this.lb_programas.Name = "lb_programas";
            this.lb_programas.Size = new System.Drawing.Size(82, 20);
            this.lb_programas.TabIndex = 33;
            this.lb_programas.Text = "Programa:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label11.Location = new System.Drawing.Point(650, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 20);
            this.label11.TabIndex = 32;
            this.label11.Text = "Muestra Modo";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label.Location = new System.Drawing.Point(650, 13);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(74, 20);
            this.label.TabIndex = 31;
            this.label.Text = "Muestra";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(892, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Programa:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(599, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Modo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(599, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Modelo:";
            // 
            // lb_folio
            // 
            this.lb_folio.AutoSize = true;
            this.lb_folio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_folio.Location = new System.Drawing.Point(1015, 62);
            this.lb_folio.Name = "lb_folio";
            this.lb_folio.Size = new System.Drawing.Size(47, 20);
            this.lb_folio.TabIndex = 35;
            this.lb_folio.Text = "Folio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(915, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Folio:";
            // 
            // dg_procesados
            // 
            this.dg_procesados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_procesados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod,
            this.plc,
            this.sime});
            this.dg_procesados.Location = new System.Drawing.Point(525, 100);
            this.dg_procesados.Name = "dg_procesados";
            this.dg_procesados.Size = new System.Drawing.Size(546, 313);
            this.dg_procesados.TabIndex = 36;
            // 
            // cod
            // 
            this.cod.HeaderText = "Codigo2D";
            this.cod.Name = "cod";
            // 
            // plc
            // 
            this.plc.HeaderText = "PLC";
            this.plc.Name = "plc";
            this.plc.Width = 200;
            // 
            // sime
            // 
            this.sime.HeaderText = "SIME";
            this.sime.Name = "sime";
            this.sime.Width = 200;
            // 
            // lst_folios
            // 
            this.lst_folios.FormattingEnabled = true;
            this.lst_folios.Location = new System.Drawing.Point(369, 97);
            this.lst_folios.Name = "lst_folios";
            this.lst_folios.Size = new System.Drawing.Size(120, 316);
            this.lst_folios.TabIndex = 37;
            // 
            // txt_tiempo
            // 
            this.txt_tiempo.Location = new System.Drawing.Point(233, 453);
            this.txt_tiempo.Name = "txt_tiempo";
            this.txt_tiempo.Size = new System.Drawing.Size(139, 20);
            this.txt_tiempo.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Tiempo milisegundos entre cada folio:";
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(223, 36);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(75, 23);
            this.btn_agregar.TabIndex = 40;
            this.btn_agregar.Text = "Agregar";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // btn_iniciar
            // 
            this.btn_iniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_iniciar.Location = new System.Drawing.Point(861, 439);
            this.btn_iniciar.Name = "btn_iniciar";
            this.btn_iniciar.Size = new System.Drawing.Size(86, 34);
            this.btn_iniciar.TabIndex = 41;
            this.btn_iniciar.Text = "Inicia";
            this.btn_iniciar.UseVisualStyleBackColor = true;
            this.btn_iniciar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_terminar
            // 
            this.btn_terminar.Enabled = false;
            this.btn_terminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_terminar.Location = new System.Drawing.Point(984, 439);
            this.btn_terminar.Name = "btn_terminar";
            this.btn_terminar.Size = new System.Drawing.Size(87, 34);
            this.btn_terminar.TabIndex = 42;
            this.btn_terminar.Text = "Termina";
            this.btn_terminar.UseVisualStyleBackColor = true;
            this.btn_terminar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Campanas en conveyor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(522, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Lista de folios procesados:";
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(452, 419);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(37, 30);
            this.btn_guardar.TabIndex = 45;
            this.btn_guardar.Text = "+";
            this.btn_guardar.UseVisualStyleBackColor = true;
            // 
            // btn_abrir
            // 
            this.btn_abrir.Location = new System.Drawing.Point(409, 419);
            this.btn_abrir.Name = "btn_abrir";
            this.btn_abrir.Size = new System.Drawing.Size(37, 30);
            this.btn_abrir.TabIndex = 46;
            this.btn_abrir.Text = "-";
            this.btn_abrir.UseVisualStyleBackColor = true;
            // 
            // Automatico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 500);
            this.Controls.Add(this.btn_abrir);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_terminar);
            this.Controls.Add(this.btn_iniciar);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.txt_tiempo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lst_folios);
            this.Controls.Add(this.dg_procesados);
            this.Controls.Add(this.lb_folio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_programas);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_codigo);
            this.Controls.Add(this.label1);
            this.Name = "Automatico";
            this.Text = "Automatico";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Automatico_FormClosing);
            this.Load += new System.EventHandler(this.Automatico_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_procesados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnl_variables;
        private System.Windows.Forms.Label lb_programas;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lb_folio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dg_procesados;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn plc;
        private System.Windows.Forms.DataGridViewTextBoxColumn sime;
        private System.Windows.Forms.ListBox lst_folios;
        private System.Windows.Forms.TextBox txt_tiempo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Button btn_iniciar;
        private System.Windows.Forms.Button btn_terminar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_abrir;
    }
}