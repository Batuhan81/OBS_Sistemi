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

namespace DönemlikStajProje
{
    public partial class ögretmen_esg : Form
    {
        public ögretmen_esg()
        {
            InitializeComponent();
        }
        Context db = new Context();
        Data.Profesor p = new Data.Profesor();
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
        private bool TumComboBoxlarDoluMu(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.SelectedIndex == -1)
                    {
                        return false; // ComboBox seçimi yapılmamışsa veya boşsa false döndür
                    }
                }
            }
            return true; // Tüm ComboBox'lar dolu ise true döndür
        }
        bool TumTextBoxlarDoluMu(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        return false; // TextBox'ın içeriği boş veya sadece boşluk karakterlerinden oluşuyorsa false döndür
                    }
                }

            }
            return true; // Tüm TextBox'lar dolu ise true döndür
        }
        private void ögretmen_esg_Load(object sender, EventArgs e)
        {
            ProfGöster();
            var unvanlar = db.Profesorler.Select(x => x.profesorUnvan).Distinct().ToList();
            foreach (var unvan in unvanlar)
            {
                UnvanAra.Items.Add(unvan);
            }
            GridRenklendir();
            txtad.Focus();
        }
        void GridRenklendir()
        {
            // DataGridView'nin AlternatingRowsDefaultCellStyle özelliğini kullanarak arka plan rengini ayarlayabilirsiniz
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // veya istediğiniz başka bir renk

            // Alternatif olarak, belirli bir renk yerine her iki satır için farklı renkler de belirleyebilirsiniz
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White; // Tek satırlar için arka plan rengi
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Çift satırlar için arka plan rengi
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (TumTextBoxlarDoluMu(groupBox1) && TumComboBoxlarDoluMu(groupBox1))
            {
                Sifrekontrol();
                if (eşleşti == true)
                {
                    if (mailmi == true)
                    {
                        if (uzantı.Text.Length != 0)
                        {
                            if (hiddenID.Text == null || hiddenID.Text == "")
                            {
                                p.profesorIsim = txtad.Text;
                                p.profesorSoyad = txtsoyad.Text;
                                p.olusturmaTarihi = DateTime.Now;
                                p.profesorParola = txtparola.Text;
                                p.profesorUnvan = txtunvan.Text;
                                p.profesorEposta = txteposta.Text;
                                p.profesorGorusmeSaatleri = txtsaatler.Text;
                                p.profesorOfisAdresi = txtadres.Text;
                                p.profesorFotoYolu = uzantı.Text;
                                db.Profesorler.Add(p);
                                timer1.Start();
                                MessageBox.Show("Yeni Kayıt Başarılı");
                            }
                            else
                            {
                                int id = Convert.ToInt32(hiddenID.Text);
                                var x = db.Profesorler.Find(id);
                                x.profesorIsim = txtad.Text;
                                x.profesorSoyad = txtsoyad.Text;
                                x.olusturmaTarihi = DateTime.Now;
                                x.profesorParola = txtparola.Text;
                                x.profesorUnvan = txtunvan.Text;
                                x.profesorEposta = txteposta.Text;
                                x.profesorFotoYolu = uzantı.Text;
                                x.profesorGorusmeSaatleri = txtsaatler.Text;
                                x.profesorOfisAdresi = txtadres.Text;
                                timer1.Start();
                                MessageBox.Show("Güncelleme İşlemi Başarılı");
                            }
                            db.SaveChanges();
                            hiddenID.Text = "";
                            Temizle();
                            ProfGöster();
                        }
                        else
                        {
                            timer1.Start();
                            MessageBox.Show("Kişiye Bir Fotoğraf Tanımlamalısınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                MessageBox.Show("Kişiye Ait tüm Alanları Doldurduğunuza Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Temizle()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            pictureBox1.Image = null;
            uzantı.Text = "";
        }
        void ProfGöster()
        {
            var ogretmenler = db.Profesorler.ToList().Select(o => new
            {
                ID = o.profesorId,
                Ad = o.profesorIsim,
                Soyad = o.profesorSoyad,
                Parola = o.profesorParola,
                Unvan = o.profesorUnvan,
                Eposta = o.profesorEposta,
                Görüşme_Saati = o.profesorGorusmeSaatleri,
                Adres = o.profesorOfisAdresi,
                Foto_Yolu = o.profesorFotoYolu,
            }).ToList();
            dataGridView1.DataSource = ogretmenler;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hiddenID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            txtad.Text = dataGridView1.CurrentRow.Cells["Ad"].Value.ToString();
            txtsoyad.Text = dataGridView1.CurrentRow.Cells["Soyad"].Value.ToString();
            txtparola.Text = dataGridView1.CurrentRow.Cells["Parola"].Value.ToString();
            txttekrar.Text = dataGridView1.CurrentRow.Cells["Parola"].Value.ToString();
            txtunvan.Text = dataGridView1.CurrentRow.Cells["Unvan"].Value.ToString();
            txteposta.Text = dataGridView1.CurrentRow.Cells["Eposta"].Value.ToString();
            txtsaatler.Text = dataGridView1.CurrentRow.Cells["Görüşme_Saati"].Value.ToString();
            txtadres.Text = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString();
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Kaydı Silmek İstediğinize Emin Misiniz ?", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (hiddenID.Text != null)
                {
                    int id = Convert.ToInt32(hiddenID.Text);
                    var x = db.Profesorler.Find(id);//Hangi tablodan silme işlemini yapacaksın ve neye göre sileceksin
                    db.Profesorler.Remove(x);
                    db.SaveChanges();
                    MessageBox.Show("Kayıt Silindi");
                    ProfGöster();
                    Temizle();
                }
            }
        }

        private void adara_TextChanged(object sender, EventArgs e)
        {
            Filtrele();
        }

        private void PostaAra_TextChanged(object sender, EventArgs e)
        {
            Filtrele();
        }
        public void Filtrele()
        {
            string adFilter = adara.Text;
            string postaFilter = PostaAra.Text;
            string UnvanFilter = UnvanAra.Text;

            var ogretmenlerQuery = db.Profesorler.AsQueryable();

            // Eğer "Tümü" seçeneği seçilmişse, filtre uygulanmayacak
            if (UnvanFilter != "Tümü")
            {
                ogretmenlerQuery = ogretmenlerQuery.Where(x => x.profesorUnvan.Contains(UnvanFilter));
            }

            var ogretmenler = ogretmenlerQuery
                                .Where(x => x.profesorIsim.Contains(adFilter) && x.profesorEposta.Contains(postaFilter))
                                .Select(o => new
                                {
                                    ID = o.profesorId,
                                    Ad = o.profesorIsim,
                                    Soyad = o.profesorSoyad,
                                    Parola = o.profesorParola,
                                    Unvan = o.profesorUnvan,
                                    Eposta = o.profesorEposta,
                                    Görüşme_Saati = o.profesorGorusmeSaatleri,
                                    Adres = o.profesorOfisAdresi,
                                }).ToList();

            dataGridView1.DataSource = ogretmenler;
        }

        private void UnvanAra_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrele();
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

                Boyutlandır(fileDialog);
            }
        }

        private void Boyutlandır(OpenFileDialog fileDialog)
        {
            // Resim uzantısını ve dosya yolunu göster
            uzantı.Visible = true;
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

        private void hiddenID_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            SendKeys.Send("{ESC}");
        }

        private void txtparola_TextChanged(object sender, EventArgs e)
        {
            SifreTürü(txtparola.Text);
        }

        private void sifreT_MouseHover(object sender, EventArgs e)
        {
            timer1.Start();
            MessageBox.Show("Şifrenizi Daha Güçlü Yapmak İçin Büyük,Küçük Harf ve Rakam Eklemeyi Deneyin", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txteposta_TextChanged(object sender, EventArgs e)
        {
            mailKOntrol(txteposta.Text);
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

        private void button2_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font baslikFont = new Font("Arial", 11, FontStyle.Bold);
            Font icerikFont = new Font("Arial", 9, FontStyle.Regular);
            PageSettings sayfaAyarları = printDocument1.DefaultPageSettings;
            int y = 75;
            int[] sutunGenislikleri = { 60, 80, 80, 150, 80, 80}; // Sütun genişlikleri
            string[] basliklar = { "No", "Ad", "Soyad", "Mail", "Unvan", "Adres" };

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
                string tc = dataGridView1.Rows[i].Cells["Unvan"].Value.ToString();
                string adres = dataGridView1.Rows[i].Cells["Adres"].Value.ToString();

                e.Graphics.DrawString(ad, icerikFont, Brushes.Black, sayfaAyarları.Margins.Left + sutunGenislikleri[0], y);
                e.Graphics.DrawString(soyad, icerikFont, Brushes.Black, sayfaAyarları.Margins.Left + sutunGenislikleri.Take(2).Sum(), y);
                e.Graphics.DrawString(mail, icerikFont, Brushes.Black, sayfaAyarları.Margins.Left + sutunGenislikleri.Take(3).Sum(), y);
                e.Graphics.DrawString(tc, icerikFont, Brushes.Black, sayfaAyarları.Margins.Left + sutunGenislikleri.Take(4).Sum(), y);
                e.Graphics.DrawString(adres, icerikFont, Brushes.Black, sayfaAyarları.Margins.Left + sutunGenislikleri.Take(5).Sum(), y);
              

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

