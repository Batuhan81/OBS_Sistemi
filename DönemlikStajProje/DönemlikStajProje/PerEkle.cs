using DönemlikStajProje.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DönemlikStajProje
{
    public partial class PerEkle : Form
    {
        public PerEkle()
        {
            InitializeComponent();
        }
        Context db = new Context();
        Data.Admin a = new Data.Admin();


        private void PerEkle_Load(object sender, EventArgs e)
        {
            AdminGoster();
            GridRenklendir();
            txtad.Focus();
        }
        bool eşleşti = true;
        void Sifrekontrol()
        {
            if (txtparola.Text == txttekrar.Text)
            {
                eşleşti = true;
            }
            else
            {
                eşleşti = false;
            }
        }
        void GridRenklendir()
        {
            // DataGridView'nin AlternatingRowsDefaultCellStyle özelliğini kullanarak arka plan rengini ayarlayabilirsiniz
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // veya istediğiniz başka bir renk

            // Alternatif olarak, belirli bir renk yerine her iki satır için farklı renkler de belirleyebilirsiniz
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White; // Tek satırlar için arka plan rengi
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Çift satırlar için arka plan rengi
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Sifrekontrol();
            if (eşleşti == true)
            {
                if (mailmi == true)
                {
                    if(uzantı.Text.Length != 0)
                    {
                        if (hiddenID.Text == null || hiddenID.Text == "")
                        {
                            a.adminIsim = txtad.Text;
                            a.adminSoyad = txtsoyad.Text;
                            a.adminParola = txtparola.Text;
                            a.adminEposta = txteposta.Text;
                            a.olusturmaTarihi = DateTime.Now;
                            a.adminFotoYolu = uzantı.Text;
                            db.Adminler.Add(a);
                            timer1.Start();
                            MessageBox.Show("Yeni Kayıt Eklendi");
                        }
                        else
                        {
                            int id = Convert.ToInt32(hiddenID.Text);
                            var x = db.Adminler.Find(id);
                            x.adminIsim = txtad.Text;
                            x.adminSoyad = txtsoyad.Text;
                            x.olusturmaTarihi = DateTime.Now;
                            x.adminParola = txtparola.Text;
                            x.adminEposta = txteposta.Text;
                            x.adminFotoYolu = uzantı.Text;
                            timer1.Start();
                            MessageBox.Show("Kayıt Güncellendi");
                        }
                        db.SaveChanges();
                        hiddenID.Text = "";
                        Temizle();
                        AdminGoster();
                    }
                    else
                    {
                        timer1.Start();
                        MessageBox.Show("Kişiye Bir Fotoğraf Tanımlamalısınız.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else
                {
                    timer1.Start();
                    MessageBox.Show("Girdiğiniz E-Posta Geçersiz '@' içermiyor.");
                }
            }
            else
            {
                MessageBox.Show("Şifreler Eşleşmiyor", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Temizle()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is System.Windows.Forms.TextBox)
                {
                    item.Text = "";
                }
            }
            uzantı.Text = "";
            pictureBox1.Image = null;
        }
        void AdminGoster()
        {
            var Admin = db.Adminler.ToList().Select(o => new
            {
                ID = o.adminId,
                Ad = o.adminIsim,
                Soyad = o.adminSoyad,
                Parola = o.adminParola,
                Eposta = o.adminEposta,
                Oluşturma_Tarihi = o.olusturmaTarihi,
                Foto_Yolu = o.adminFotoYolu,
            }).ToList();
            dataGridView1.DataSource = Admin;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Kaydı Silmek İstediğinize Emin Misiniz ?", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (hiddenID.Text != null)
                {
                    int id = Convert.ToInt32(hiddenID.Text);
                    var x = db.Adminler.Find(id);//Hangi tablodan silme işlemini yapacaksın ve neye göre sileceksin
                    db.Adminler.Remove(x);
                    db.SaveChanges();
                    MessageBox.Show("Kayıt Silindi");
                    AdminGoster();
                    Temizle();
                    hiddenID.Text = "";
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hiddenID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            txtad.Text = dataGridView1.CurrentRow.Cells["Ad"].Value.ToString();
            txtsoyad.Text = dataGridView1.CurrentRow.Cells["Soyad"].Value.ToString();
            txtparola.Text = dataGridView1.CurrentRow.Cells["Parola"].Value.ToString();
            txttekrar.Text = dataGridView1.CurrentRow.Cells["Parola"].Value.ToString();
            txteposta.Text = dataGridView1.CurrentRow.Cells["Eposta"].Value.ToString();
            uzantı.Text = dataGridView1.CurrentRow.Cells["Foto_Yolu"].Value.ToString();
            // Seçilen satırdaki fotoğraf yolu
            string fotoYolu = dataGridView1.CurrentRow.Cells["Foto_Yolu"].Value.ToString();
            if (!string.IsNullOrEmpty(fotoYolu))
            {
                // Fotoğraf yolu boş değilse, PictureBox'a yükle
                pictureBox1.ImageLocation = fotoYolu;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Resmi PictureBox boyutuna göre ölçekle
            }
            else
            {
                // Fotoğraf yolu boşsa, PictureBox'ı temizle
                pictureBox1.Image = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Png Dosyaları |*.png";
            fileDialog.FilterIndex = 1;
            fileDialog.RestoreDirectory = true;//En son nerede hangi klasör açık bırakıldıysa oradan devam ediyor tekrar açılınca
            fileDialog.CheckFileExists = true;//dosyanın olup olmadığını kontrol eder.dosya eğer yoksa hata mesajı verir
            fileDialog.Title = "Dosya Seçiniz";//Açılan pencerenin adını buna çevirir.
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen fotoğrafı PictureBox'ta göster
                pictureBox1.Image = Image.FromFile(fileDialog.FileName);

                // Resim uzantısını ve dosya yolunu göster
                uzantı.Text = fileDialog.FileName;
                string filePath = fileDialog.FileName;
                // Resmi dosyadan yükle
                Image originalImage = Image.FromFile(filePath);

                // PictureBox'ın boyutlarını al
                int pictureBoxWidth = pictureBox1.Width;
                int pictureBoxHeight = pictureBox1.Height;

                // Resmi PictureBox'ın boyutlarına uygun olarak ölçekle
                Image boyutlandır = ResizeImage(originalImage, pictureBoxWidth, pictureBoxHeight);

                // PictureBox'a ölçeklenmiş resmi ata
                pictureBox1.Image = boyutlandır;
            }
        }
        // Resmi belirli bir boyuta ölçeklemek için yardımcı bir metot
        private Image ResizeImage(Image image, int width, int height)
        {
            Bitmap boyutlandır = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(boyutlandır))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return boyutlandır;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void uzantı_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            SendKeys.Send("{ESC}");
        }
        void SifreTürü(string sifre)
        {
            bool buyukharf = false;
            bool kucukharf = false;
            bool rakam = false;
            foreach (char c in sifre)
            {
                if (char.IsUpper(c))
                {
                    buyukharf = true;
                }
                if (char.IsLower(c))
                {
                    kucukharf = true;
                }
                if (char.IsDigit(c))
                {
                    rakam = true;
                }
            }
            if (buyukharf && kucukharf && rakam && sifre.Length > 8)
            {
                sifreT.Text = "Güçlü Şifre";
            }
            else if (kucukharf && rakam && sifre.Length < 8)
            {
                sifreT.Text = "Zor Şifre";
            }
            else if (rakam && sifre.Length < 5)
            {
                sifreT.Text = "Kolay Şifre";
            }
            else
            {
                sifreT.Text = "Kolay Şifre";
            }
            if (sifre.Length == 0)
            {
                sifreT.Text = "";
            }
        }
        private void txtparola_TextChanged(object sender, EventArgs e)
        {
            SifreTürü(txtparola.Text);
        }

        private void sifreT_MouseHover(object sender, EventArgs e)
        {
            timer1.Start();
            MessageBox.Show("Şifrenizi Daha Güçlü Yapmak İçin Büyük,Küçük Harf ve Rakam Karışımı Bir Şifre Deneyin", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        bool mailmi = false;
        void mailKOntrol(string mail)
        {
            foreach (char c in mail)
            {
                if (c == '@')
                {
                    mailmi = true;
                }

            }
        }
        private void txteposta_TextChanged(object sender, EventArgs e)
        {
            mailKOntrol(txteposta.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            pageSetupDialog1.PageSettings = printDocument1.DefaultPageSettings;
            if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font baslikFont = new Font("Arial", 11, FontStyle.Bold);
            Font icerikFont = new Font("Arial", 9, FontStyle.Regular);
            PageSettings sayfaAyarları = printDocument1.DefaultPageSettings;
            int y = 75;
            int[] sutunGenislikleri = { 60, 80, 80, 150, 80, 80 }; // Sütun genişlikleri
            string[] basliklar = { "No", "Ad", "Soyad", "Mail" };

            // Başlık yazdırma
            for (int i = 0; i < basliklar.Length; i++)
            {
                e.Graphics.DrawString(basliklar[i], baslikFont, Brushes.Black, sayfaAyarları.Margins.Left + sutunGenislikleri.Take(i).Sum(), y);
            }

            e.Graphics.DrawLine(new Pen(Color.Black, 1), sayfaAyarları.Margins.Left, y + 20, sayfaAyarları.PaperSize.Width - sayfaAyarları.Margins.Right, y + 20);
            // Verileri yazdırma
            int satir = dataGridView1.Rows.Count;
            for (int i = 0; i < satir; i++)
            {
                y += 25;
                e.Graphics.DrawString((i + 1).ToString(), icerikFont, Brushes.Black, sayfaAyarları.Margins.Left, y);

                string ad = dataGridView1.Rows[i].Cells["Ad"].Value.ToString();
                string soyad = dataGridView1.Rows[i].Cells["Soyad"].Value.ToString();
                string mail = dataGridView1.Rows[i].Cells["Eposta"].Value.ToString();
              

                e.Graphics.DrawString(ad, icerikFont, Brushes.Black, sayfaAyarları.Margins.Left + sutunGenislikleri[0], y);
                e.Graphics.DrawString(soyad, icerikFont, Brushes.Black, sayfaAyarları.Margins.Left + sutunGenislikleri.Take(2).Sum(), y);
                e.Graphics.DrawString(mail, icerikFont, Brushes.Black, sayfaAyarları.Margins.Left + sutunGenislikleri.Take(3).Sum(), y);

                if (y + 155 > sayfaAyarları.PaperSize.Height + 185 - sayfaAyarları.Margins.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            e.HasMorePages = false;
        }
    }
}
