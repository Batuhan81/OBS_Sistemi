namespace DönemlikStajProje
{
    partial class Bölüm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bölüm));
            this.fHoca = new System.Windows.Forms.ComboBox();
            this.Fad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridFakülte = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.hiddenHoca = new System.Windows.Forms.TextBox();
            this.hiddenFakülte = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bhoca = new System.Windows.Forms.ComboBox();
            this.bAd = new System.Windows.Forms.TextBox();
            this.gridbölüm = new System.Windows.Forms.DataGridView();
            this.hiddenBölüm = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridFakülte)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridbölüm)).BeginInit();
            this.SuspendLayout();
            // 
            // fHoca
            // 
            this.fHoca.FormattingEnabled = true;
            this.fHoca.Location = new System.Drawing.Point(202, 146);
            this.fHoca.Name = "fHoca";
            this.fHoca.Size = new System.Drawing.Size(121, 28);
            this.fHoca.TabIndex = 0;
            this.fHoca.SelectedIndexChanged += new System.EventHandler(this.fHoca_SelectedIndexChanged);
            // 
            // Fad
            // 
            this.Fad.Location = new System.Drawing.Point(202, 54);
            this.Fad.Name = "Fad";
            this.Fad.Size = new System.Drawing.Size(121, 27);
            this.Fad.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fakülte Adı:";
            // 
            // gridFakülte
            // 
            this.gridFakülte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFakülte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridFakülte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridFakülte.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridFakülte.Location = new System.Drawing.Point(800, 46);
            this.gridFakülte.Name = "gridFakülte";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFakülte.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridFakülte.RowHeadersWidth = 51;
            this.gridFakülte.RowTemplate.Height = 24;
            this.gridFakülte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFakülte.Size = new System.Drawing.Size(1126, 400);
            this.gridFakülte.TabIndex = 17;
            this.gridFakülte.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFakülte_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fHoca);
            this.groupBox1.Controls.Add(this.Fad);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(115, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 410);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fakülte İşlemleri";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ImageKey = "Kaydet.png";
            this.button1.ImageList = this.ımageList1;
            this.button1.Location = new System.Drawing.Point(69, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 102);
            this.button1.TabIndex = 4;
            this.button1.Text = "Kaydet";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fakülte Hocası";
            // 
            // hiddenHoca
            // 
            this.hiddenHoca.Location = new System.Drawing.Point(577, 179);
            this.hiddenHoca.Name = "hiddenHoca";
            this.hiddenHoca.Size = new System.Drawing.Size(121, 22);
            this.hiddenHoca.TabIndex = 5;
            this.hiddenHoca.Visible = false;
            // 
            // hiddenFakülte
            // 
            this.hiddenFakülte.Location = new System.Drawing.Point(577, 140);
            this.hiddenFakülte.Name = "hiddenFakülte";
            this.hiddenFakülte.Size = new System.Drawing.Size(121, 22);
            this.hiddenFakülte.TabIndex = 19;
            this.hiddenFakülte.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.bhoca);
            this.groupBox2.Controls.Add(this.bAd);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(115, 560);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 410);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bölüm İşlemleri";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ImageKey = "Kaydet.png";
            this.button2.ImageList = this.ımageList1;
            this.button2.Location = new System.Drawing.Point(69, 271);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 102);
            this.button2.TabIndex = 4;
            this.button2.Text = "Kaydet";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Bölüm Hocası:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Bölüm Adı:";
            // 
            // bhoca
            // 
            this.bhoca.FormattingEnabled = true;
            this.bhoca.Location = new System.Drawing.Point(166, 143);
            this.bhoca.Name = "bhoca";
            this.bhoca.Size = new System.Drawing.Size(157, 28);
            this.bhoca.TabIndex = 0;
            this.bhoca.SelectedIndexChanged += new System.EventHandler(this.bhoca_SelectedIndexChanged);
            // 
            // bAd
            // 
            this.bAd.Location = new System.Drawing.Point(166, 51);
            this.bAd.Name = "bAd";
            this.bAd.Size = new System.Drawing.Size(157, 27);
            this.bAd.TabIndex = 1;
            // 
            // gridbölüm
            // 
            this.gridbölüm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridbölüm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridbölüm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridbölüm.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridbölüm.Location = new System.Drawing.Point(800, 560);
            this.gridbölüm.Name = "gridbölüm";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridbölüm.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridbölüm.RowHeadersWidth = 51;
            this.gridbölüm.RowTemplate.Height = 24;
            this.gridbölüm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridbölüm.Size = new System.Drawing.Size(1126, 400);
            this.gridbölüm.TabIndex = 20;
            this.gridbölüm.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridbölüm_CellClick);
            // 
            // hiddenBölüm
            // 
            this.hiddenBölüm.Location = new System.Drawing.Point(577, 216);
            this.hiddenBölüm.Name = "hiddenBölüm";
            this.hiddenBölüm.Size = new System.Drawing.Size(121, 22);
            this.hiddenBölüm.TabIndex = 21;
            this.hiddenBölüm.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "Kaydet.png");
            // 
            // Bölüm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1839, 1055);
            this.Controls.Add(this.hiddenBölüm);
            this.Controls.Add(this.gridbölüm);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.hiddenFakülte);
            this.Controls.Add(this.hiddenHoca);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridFakülte);
            this.Name = "Bölüm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bölüm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Bölüm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridFakülte)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridbölüm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox fHoca;
        private System.Windows.Forms.TextBox Fad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridFakülte;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hiddenHoca;
        private System.Windows.Forms.TextBox hiddenFakülte;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox bhoca;
        private System.Windows.Forms.TextBox bAd;
        private System.Windows.Forms.DataGridView gridbölüm;
        private System.Windows.Forms.TextBox hiddenBölüm;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList ımageList1;
    }
}