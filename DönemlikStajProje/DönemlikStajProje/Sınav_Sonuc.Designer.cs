namespace DönemlikStajProje
{
    partial class Sınav_Sonuc
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sınav_Sonuc));
            this.label3 = new System.Windows.Forms.Label();
            this.gridOgrenci = new System.Windows.Forms.DataGridView();
            this.txtdersadı = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.not1 = new System.Windows.Forms.TextBox();
            this.not2 = new System.Windows.Forms.TextBox();
            this.txtort = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.hiddenOGrID = new System.Windows.Forms.TextBox();
            this.comboDers = new System.Windows.Forms.ComboBox();
            this.hiddenDersID = new System.Windows.Forms.TextBox();
            this.comboÖgrenci = new System.Windows.Forms.ComboBox();
            this.hiddenNotID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ogrDers = new System.Windows.Forms.TextBox();
            this.ogrfiltre = new System.Windows.Forms.ComboBox();
            this.dersfiltre = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridOgrenci)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(41, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Öğrenci Adı:";
            // 
            // gridOgrenci
            // 
            this.gridOgrenci.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridOgrenci.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridOgrenci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridOgrenci.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridOgrenci.Location = new System.Drawing.Point(361, 110);
            this.gridOgrenci.Name = "gridOgrenci";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridOgrenci.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridOgrenci.RowHeadersWidth = 51;
            this.gridOgrenci.RowTemplate.Height = 24;
            this.gridOgrenci.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridOgrenci.Size = new System.Drawing.Size(1275, 527);
            this.gridOgrenci.TabIndex = 17;
            this.gridOgrenci.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOgrenci_CellClick);
            // 
            // txtdersadı
            // 
            this.txtdersadı.AutoSize = true;
            this.txtdersadı.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtdersadı.Location = new System.Drawing.Point(52, 75);
            this.txtdersadı.Name = "txtdersadı";
            this.txtdersadı.Size = new System.Drawing.Size(77, 18);
            this.txtdersadı.TabIndex = 18;
            this.txtdersadı.Text = "Ders Adı:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(64, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 18);
            this.label5.TabIndex = 19;
            this.label5.Text = "1. Sınavı:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(69, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 18);
            this.label6.TabIndex = 20;
            this.label6.Text = "2.Sınavı:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(46, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 18);
            this.label7.TabIndex = 21;
            this.label7.Text = "Ortalaması:";
            // 
            // not1
            // 
            this.not1.Location = new System.Drawing.Point(165, 107);
            this.not1.Name = "not1";
            this.not1.Size = new System.Drawing.Size(141, 28);
            this.not1.TabIndex = 23;
            // 
            // not2
            // 
            this.not2.Location = new System.Drawing.Point(165, 171);
            this.not2.Name = "not2";
            this.not2.Size = new System.Drawing.Size(141, 28);
            this.not2.TabIndex = 24;
            // 
            // txtort
            // 
            this.txtort.Location = new System.Drawing.Point(165, 235);
            this.txtort.Name = "txtort";
            this.txtort.Size = new System.Drawing.Size(141, 28);
            this.txtort.TabIndex = 25;
            this.txtort.Click += new System.EventHandler(this.txtort_Click);
            // 
            // button1
            // 
            this.button1.ImageKey = "Kaydet.png";
            this.button1.ImageList = this.ımageList1;
            this.button1.Location = new System.Drawing.Point(84, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 86);
            this.button1.TabIndex = 26;
            this.button1.Text = "Kaydet";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hiddenOGrID
            // 
            this.hiddenOGrID.Location = new System.Drawing.Point(1137, 48);
            this.hiddenOGrID.Name = "hiddenOGrID";
            this.hiddenOGrID.Size = new System.Drawing.Size(141, 22);
            this.hiddenOGrID.TabIndex = 27;
            this.hiddenOGrID.Visible = false;
            // 
            // comboDers
            // 
            this.comboDers.FormattingEnabled = true;
            this.comboDers.Location = new System.Drawing.Point(153, 74);
            this.comboDers.Name = "comboDers";
            this.comboDers.Size = new System.Drawing.Size(141, 24);
            this.comboDers.TabIndex = 28;
            this.comboDers.SelectedIndexChanged += new System.EventHandler(this.comboDers_SelectedIndexChanged);
            this.comboDers.TextChanged += new System.EventHandler(this.comboDers_TextChanged);
            // 
            // hiddenDersID
            // 
            this.hiddenDersID.Location = new System.Drawing.Point(1137, 20);
            this.hiddenDersID.Name = "hiddenDersID";
            this.hiddenDersID.Size = new System.Drawing.Size(141, 22);
            this.hiddenDersID.TabIndex = 29;
            this.hiddenDersID.Visible = false;
            // 
            // comboÖgrenci
            // 
            this.comboÖgrenci.FormattingEnabled = true;
            this.comboÖgrenci.Location = new System.Drawing.Point(165, 41);
            this.comboÖgrenci.Name = "comboÖgrenci";
            this.comboÖgrenci.Size = new System.Drawing.Size(141, 30);
            this.comboÖgrenci.TabIndex = 30;
            this.comboÖgrenci.SelectedIndexChanged += new System.EventHandler(this.comboÖgrenci_SelectedIndexChanged);
            // 
            // hiddenNotID
            // 
            this.hiddenNotID.Location = new System.Drawing.Point(1137, 76);
            this.hiddenNotID.Name = "hiddenNotID";
            this.hiddenNotID.Size = new System.Drawing.Size(141, 22);
            this.hiddenNotID.TabIndex = 31;
            this.hiddenNotID.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.not2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.not1);
            this.groupBox1.Controls.Add(this.txtort);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboÖgrenci);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 480);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bilgiler";
            // 
            // ogrDers
            // 
            this.ogrDers.Location = new System.Drawing.Point(1356, 48);
            this.ogrDers.Name = "ogrDers";
            this.ogrDers.Size = new System.Drawing.Size(141, 22);
            this.ogrDers.TabIndex = 43;
            this.ogrDers.Visible = false;
            // 
            // ogrfiltre
            // 
            this.ogrfiltre.FormattingEnabled = true;
            this.ogrfiltre.Items.AddRange(new object[] {
            "Tümü"});
            this.ogrfiltre.Location = new System.Drawing.Point(192, 37);
            this.ogrfiltre.Name = "ogrfiltre";
            this.ogrfiltre.Size = new System.Drawing.Size(141, 28);
            this.ogrfiltre.TabIndex = 31;
            this.ogrfiltre.SelectedIndexChanged += new System.EventHandler(this.ogrfiltre_SelectedIndexChanged);
            // 
            // dersfiltre
            // 
            this.dersfiltre.FormattingEnabled = true;
            this.dersfiltre.Items.AddRange(new object[] {
            "Tümü"});
            this.dersfiltre.Location = new System.Drawing.Point(521, 37);
            this.dersfiltre.Name = "dersfiltre";
            this.dersfiltre.Size = new System.Drawing.Size(141, 28);
            this.dersfiltre.TabIndex = 44;
            this.dersfiltre.SelectedIndexChanged += new System.EventHandler(this.dersfiltre_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(38, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 31;
            this.label4.Text = "Öğrenci Adı:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(414, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 18);
            this.label8.TabIndex = 45;
            this.label8.Text = "Ders Adı:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dersfiltre);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.ogrfiltre);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(450, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(675, 88);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtre Seçenkleri";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "Kaydet.png");
            // 
            // Sınav_Sonuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1645, 650);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ogrDers);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtdersadı);
            this.Controls.Add(this.hiddenNotID);
            this.Controls.Add(this.hiddenDersID);
            this.Controls.Add(this.hiddenOGrID);
            this.Controls.Add(this.gridOgrenci);
            this.Controls.Add(this.comboDers);
            this.Name = "Sınav_Sonuc";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Not Paneli";
            this.Load += new System.EventHandler(this.Sınav_Sonuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridOgrenci)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gridOgrenci;
        private System.Windows.Forms.Label txtdersadı;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox not1;
        private System.Windows.Forms.TextBox not2;
        private System.Windows.Forms.TextBox txtort;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox hiddenOGrID;
        private System.Windows.Forms.ComboBox comboDers;
        private System.Windows.Forms.TextBox hiddenDersID;
        private System.Windows.Forms.ComboBox comboÖgrenci;
        private System.Windows.Forms.TextBox hiddenNotID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ogrDers;
        private System.Windows.Forms.ComboBox ogrfiltre;
        private System.Windows.Forms.ComboBox dersfiltre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList ımageList1;
    }
}