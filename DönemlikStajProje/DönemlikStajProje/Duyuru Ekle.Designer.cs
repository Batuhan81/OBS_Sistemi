namespace DönemlikStajProje
{
    partial class Duyuru_Ekle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Duyuru_Ekle));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.duyuruYapan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmetin = new System.Windows.Forms.TextBox();
            this.hiddenduyuruID = new System.Windows.Forms.TextBox();
            this.gridDuyuru = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.başlık = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dosyaEkle = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridDuyuru)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ImageKey = "Duyuru Ekle.png";
            this.button1.ImageList = this.ımageList1;
            this.button1.Location = new System.Drawing.Point(232, 689);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 108);
            this.button1.TabIndex = 4;
            this.button1.Text = "Duyuru Ekle";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "Dosya Ekle2.png");
            this.ımageList1.Images.SetKeyName(1, "Duyuru Ekle.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(7, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Duyuruyu Yapan:";
            // 
            // duyuruYapan
            // 
            this.duyuruYapan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.duyuruYapan.Location = new System.Drawing.Point(184, 75);
            this.duyuruYapan.Name = "duyuruYapan";
            this.duyuruYapan.Size = new System.Drawing.Size(355, 24);
            this.duyuruYapan.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(31, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Duyuru Metni:";
            // 
            // txtmetin
            // 
            this.txtmetin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtmetin.Location = new System.Drawing.Point(184, 187);
            this.txtmetin.Multiline = true;
            this.txtmetin.Name = "txtmetin";
            this.txtmetin.Size = new System.Drawing.Size(355, 384);
            this.txtmetin.TabIndex = 2;
            // 
            // hiddenduyuruID
            // 
            this.hiddenduyuruID.Location = new System.Drawing.Point(11, 506);
            this.hiddenduyuruID.Name = "hiddenduyuruID";
            this.hiddenduyuruID.Size = new System.Drawing.Size(110, 22);
            this.hiddenduyuruID.TabIndex = 6;
            this.hiddenduyuruID.Visible = false;
            // 
            // gridDuyuru
            // 
            this.gridDuyuru.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDuyuru.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDuyuru.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDuyuru.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridDuyuru.Location = new System.Drawing.Point(558, 77);
            this.gridDuyuru.Name = "gridDuyuru";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDuyuru.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridDuyuru.RowHeadersWidth = 51;
            this.gridDuyuru.RowTemplate.Height = 24;
            this.gridDuyuru.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDuyuru.Size = new System.Drawing.Size(1126, 706);
            this.gridDuyuru.TabIndex = 16;
            this.gridDuyuru.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDuyuru_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(536, 40);
            this.label3.TabIndex = 17;
            this.label3.Text = "Sınav Tarihi,Ders Programı ve Akademik Takvim Paylaşılacağı \r\n            Zaman B" +
    "urada Yazdığı Şekilde Paylaşınız";
            // 
            // başlık
            // 
            this.başlık.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.başlık.Location = new System.Drawing.Point(184, 131);
            this.başlık.Name = "başlık";
            this.başlık.Size = new System.Drawing.Size(355, 24);
            this.başlık.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(25, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Duyuru Başlık:";
            // 
            // dosyaEkle
            // 
            this.dosyaEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dosyaEkle.ImageKey = "Dosya Ekle2.png";
            this.dosyaEkle.ImageList = this.ımageList1;
            this.dosyaEkle.Location = new System.Drawing.Point(232, 604);
            this.dosyaEkle.Name = "dosyaEkle";
            this.dosyaEkle.Size = new System.Drawing.Size(222, 71);
            this.dosyaEkle.TabIndex = 3;
            this.dosyaEkle.Text = "Dosya Ekle";
            this.dosyaEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.dosyaEkle.UseVisualStyleBackColor = true;
            this.dosyaEkle.Click += new System.EventHandler(this.dosyaEkle_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImageList = this.ımageList1;
            this.label5.Location = new System.Drawing.Point(121, 586);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 21;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox1.Location = new System.Drawing.Point(12, 314);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(135, 24);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Aktif Duyuru";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Duyuru_Ekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1717, 810);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dosyaEkle);
            this.Controls.Add(this.başlık);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridDuyuru);
            this.Controls.Add(this.hiddenduyuruID);
            this.Controls.Add(this.txtmetin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.duyuruYapan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Duyuru_Ekle";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duyuru Paneli";
            this.Load += new System.EventHandler(this.Duyuru_Ekle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDuyuru)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox duyuruYapan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtmetin;
        private System.Windows.Forms.TextBox hiddenduyuruID;
        private System.Windows.Forms.DataGridView gridDuyuru;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox başlık;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button dosyaEkle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList ımageList1;
    }
}