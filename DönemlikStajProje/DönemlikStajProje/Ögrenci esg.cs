using DönemlikStajProje.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DönemlikStajProje
{
    public partial class Ögrenci_esg : Form
    {
        public Ögrenci_esg()
        {
            InitializeComponent();
        }
        Context db = new Context();
        Data.Ogrenci o = new Data.Ogrenci();
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
        bool tceşleşti = false;
        void Tc_Kontrol()
        {
            int girilenTc = Convert.ToInt32(txttc.Text);

            // Veritabanında girilen TC ile aynı olan bir öğrenci var mı kontrol et
            var eskiOgrenci = db.Ogrenciler.FirstOrDefault(o => o.ogrenciTc == girilenTc);

            // Eğer eski bir öğrenci varsa tceşleşti'yi true yap
            if (eskiOgrenci != null)
            {
                tceşleşti = true;
            }
            else
            {
                tceşleşti = false;
            }
        }
        bool noeşleşti = false;
        void NoKontol()
        {
            int girilenno = Convert.ToInt32(txtno.Text);

            // Veritabanında girilen TC ile aynı olan bir öğrenci var mı kontrol et
            var eskiOgrenci = db.Ogrenciler.FirstOrDefault(o => o.ogrenciNo == girilenno);

            // Eğer eski bir öğrenci varsa tceşleşti'yi true yap
            if (eskiOgrenci != null)
            {
                noeşleşti = true;
            }
            else
            {
                noeşleşti = false;
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (TumTextBoxlarDoluMu(groupBox1) && TumComboBoxlarDoluMu(groupBox1))
            {
                Tc_Kontrol();
                NoKontol();


                Sifrekontrol();
                if (eşleşti == true)
                {
                    if (mailmi == true)
                    {
                        if (uzantı.Text.Length != 0)
                        {
                            if (hiddenID.Text == null || hiddenID.Text == "")
                            {
                                if (tceşleşti == false)
                                {
                                    if (noeşleşti == false)
                                    {
                                        o.ogrenciIsim = txtad.Text;
                                        o.ogrenciSoyad = txtsoyad.Text;
                                        o.ogrenciParola = txtparola.Text;
                                        o.ogrenciEposta = txteposta.Text;
                                        o.ogrenciDanisman = Convert.ToInt32(hiddenHoca.Text);
                                        o.ogrenciTc = Convert.ToInt32(txttc.Text);
                                        o.ogrenciNo = Convert.ToInt32(txtno.Text);
                                        o.ogrenciDogumTarihi = Convert.ToDateTime(dtarihi.Text);
                                        o.ogrenciCinsiyet = Convert.ToBoolean(combocinsiyet.SelectedIndex);
                                        o.ogrenciOlusturmaTarihi = DateTime.Now;
                                        o.ogrenciBolum = Convert.ToInt32(hiddenBölüm.Text);
                                        o.OgrenciFotoYolu = uzantı.Text;
                                        db.Ogrenciler.Add(o);
                                        timer1.Start();
                                        MessageBox.Show("Yeni Öğrenci Kayıt Edildi");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Girilen Öğrenci Nosu Sisteme Zaten Kayıtlı", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Girilen Tc başka Bir Kayıtla Eşleşiyor", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                int id = Convert.ToInt32(hiddenID.Text);
                                var x = db.Ogrenciler.Find(id);
                                x.ogrenciIsim = txtad.Text;
                                x.ogrenciSoyad = txtsoyad.Text;
                                x.ogrenciParola = txtparola.Text;
                                x.ogrenciEposta = txteposta.Text;
                                x.ogrenciDanisman = Convert.ToInt32(hiddenHoca.Text);
                                x.ogrenciTc = Convert.ToInt32(txttc.Text);
                                x.ogrenciNo = Convert.ToInt32(txtno.Text);
                                x.ogrenciDogumTarihi = Convert.ToDateTime(dtarihi.Text);
                                x.ogrenciCinsiyet = Convert.ToBoolean(combocinsiyet.SelectedIndex);
                                x.ogrenciOlusturmaTarihi = DateTime.Now;
                                x.OgrenciFotoYolu = uzantı.Text;
                                x.ogrenciBolum = Convert.ToInt32(hiddenBölüm.Text);
                                timer1.Start();
                                MessageBox.Show("Öğrenci Bilgileri Güncellendi");
                            }
                            db.SaveChanges();
                            hiddenID.Text = "";
                            Temizle();
                            OgrGöster();
                            mailmi = false;
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
                MessageBox.Show("Öğrenciye Ait tüm Alanları Doldurduğunuza Emin Olunuz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
            uzantı.Text = "";
            pictureBox1.Image = null;
            dtarihi.Text = "";
        }
        public void OgrGöster()
        {
            var ogrenciler = db.Ogrenciler.ToList().Select(o => new
            {
                ID = o.ogrenciId,
                Ad = o.ogrenciIsim,
                Soyad = o.ogrenciSoyad,
                Mail = o.ogrenciEposta,
                Tc = o.ogrenciTc,
                Ogr_No = o.ogrenciNo,
                Doğum_Tarihi = o.ogrenciDogumTarihi,
                Şifre = o.ogrenciParola,
                Bölüm = db.Bolumler.FirstOrDefault(b => b.bolumId == o.ogrenciBolum)?.bolumIsim, // Bölüm ismini al
                Danışman = db.Profesorler.FirstOrDefault(b => b.profesorId == o.ogrenciDanisman)?.profesorIsim,
                Cinsiyet = o.ogrenciCinsiyet ? "Kadın" : "Erkek", // Burada dönüşüm yapılıyor
                Foto_Yolu = o.OgrenciFotoYolu,
                Kayıt_Tarihi = o.ogrenciOlusturmaTarihi
            }).ToList();

            dataGridView1.DataSource = ogrenciler;
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
        int No = 1;
        Dictionary<string, int> bölümBaşlangıçNumaraları = new Dictionary<string, int>();

        // Bölümün en yüksek öğrenci numarasını almak için bir fonksiyon
        int EnYüksekOgrenciNo(int bolumID)
        {
            // Veritabanından bölümün en yüksek öğrenci numarasını al
            var enYuksekNo = db.Ogrenciler
                      .Where(o => o.ogrenciBolum == bolumID)
                      .Max(o => (int?)o.ogrenciNo); // Bu satırda null olabilen bir integer dönüş değeri kullanıyoruz


            // Eğer veritabanında öğrenci yoksa veya en yüksek numara null ise 0 döndür
            if (enYuksekNo == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(enYuksekNo);
            }
        }

        int bolumID;
        void YeniOGRno()
        {
            string secilenBolum = combobolum.SelectedItem.ToString();
            bolumID = Convert.ToInt32(hiddenBölüm.Text);

            // Seçilen bölümün en yüksek öğrenci numarasını al
            int enYuksekNo = EnYüksekOgrenciNo(bolumID);

            // Yeni öğrenci numarasını oluştur
            if (enYuksekNo == 0)
            {
                txtno.Text = $"{DateTime.Now.Year}{bolumID}{1}";
            }
            else
            {
                txtno.Text = $"{enYuksekNo + 1}";
            }
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

        private void Ögrenci_esg_Load(object sender, EventArgs e)
        {
            OgrGöster();
            GridRenklendir();
            ComboHocaDoldur();
            BolumDoldur();
            combobolum.Focus();
        }
        void BolumDoldur()
        {
            // Tüm dersleri veritabanından al
            var tumDersler = db.Bolumler.ToList();

            // ComboBox'a ders isimlerini yükle
            foreach (var ders in tumDersler)
            {
                combobolum.Items.Add(ders.bolumIsim);
            }
        }

        void ComboHocaDoldur()
        {
            // Tüm dersleri veritabanından al
            var tumDersler = db.Profesorler.ToList();

            // ComboBox'a ders isimlerini yükle
            foreach (var ders in tumDersler)
            {
                combodanısman.Items.Add(ders.profesorIsim);
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


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hiddenID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            txtad.Text = dataGridView1.CurrentRow.Cells["Ad"].Value.ToString();
            txtsoyad.Text = dataGridView1.CurrentRow.Cells["Soyad"].Value.ToString();
            txtparola.Text = dataGridView1.CurrentRow.Cells["Şifre"].Value.ToString();
            txttekrar.Text = dataGridView1.CurrentRow.Cells["Şifre"].Value.ToString();
            txteposta.Text = dataGridView1.CurrentRow.Cells["Mail"].Value.ToString();
            txttc.Text = dataGridView1.CurrentRow.Cells["Tc"].Value.ToString();
            txtno.Text = dataGridView1.CurrentRow.Cells["Ogr_No"].Value.ToString();
            dtarihi.Text = dataGridView1.CurrentRow.Cells["Doğum_Tarihi"].Value.ToString();
            combobolum.Text = dataGridView1.CurrentRow.Cells["Bölüm"].Value.ToString();
            combocinsiyet.Text = dataGridView1.CurrentRow.Cells["Cinsiyet"].Value.ToString();
            combodanısman.Text = dataGridView1.CurrentRow.Cells["Danışman"].Value.ToString();
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
                    var x = db.Ogrenciler.Find(id);//Hangi tablodan silme işlemini yapacaksın ve neye göre sileceksin
                    db.Ogrenciler.Remove(x);
                    db.SaveChanges();
                    MessageBox.Show("Kayıt Silindi");
                    OgrGöster();
                    Temizle();
                    hiddenID.Text = "";
                }
            }
        }
        string secilenbölümAd;
        private void combobolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilenbölümAd = combobolum.SelectedItem.ToString();

            var secilenDers = db.Bolumler.FirstOrDefault(d => d.bolumIsim == secilenbölümAd);

            if (secilenDers != null)
            {
                hiddenBölüm.Text = secilenDers.bolumId.ToString();
            }
            else
            {
                hiddenBölüm.Text = "";
            }
            YeniOGRno();
        }
        string secilenHoca;
        private void combodanısman_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilenHoca = combodanısman.SelectedItem.ToString();

            var secilenDanısman = db.Profesorler.FirstOrDefault(d => d.profesorIsim == secilenHoca);

            if (secilenDanısman != null)
            {
                hiddenHoca.Text = secilenDanısman.profesorId.ToString();
            }
            else
            {
                hiddenHoca.Text = "";
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
        int i = 0;
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font baslikFont = new Font("Arial", 11, FontStyle.Bold);
            Font icerikFont = new Font("Arial", 9, FontStyle.Regular);
            PageSettings sayfaAyarları = printDocument1.DefaultPageSettings;
            int y = 75;
            int[] sutunGenislikleri = { 30, 60, 70, 150, 80, 80, 90, 90 }; // Sütun genişlikleri
            string[] basliklar = { "No", "Ad", "Soyad", "Mail", "TC", "Ogr_No", "Bölüm", "Danışman" };

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
                string mail = dataGridView1.Rows[i].Cells["Mail"].Value.ToString();
                string tc = dataGridView1.Rows[i].Cells["TC"].Value.ToString();
                string ogrNo = dataGridView1.Rows[i].Cells["Ogr_No"].Value.ToString();
                string bolum = dataGridView1.Rows[i].Cells["Bölüm"].Value.ToString();
                string danisman = dataGridView1.Rows[i].Cells["Danışman"].Value.ToString();

                e.Graphics.DrawString(ad, icerikFont, Brushes.Black, sayfaAyarları.Margins.Left + sutunGenislikleri[0], y);
                e.Graphics.DrawString(soyad, icerikFont, Brushes.Black, sayfaAyarları.Margins.Left + sutunGenislikleri.Take(2).Sum(), y);
                e.Graphics.DrawString(mail, icerikFont, Brushes.Black, sayfaAyarları.Margins.Left + sutunGenislikleri.Take(3).Sum(), y);
                e.Graphics.DrawString(tc, icerikFont, Brushes.Black, sayfaAyarları.Margins.Left + sutunGenislikleri.Take(4).Sum(), y);
                e.Graphics.DrawString(ogrNo, icerikFont, Brushes.Black, sayfaAyarları.Margins.Left + sutunGenislikleri.Take(5).Sum(), y);
                e.Graphics.DrawString(bolum, icerikFont, Brushes.Black, sayfaAyarları.Margins.Left + sutunGenislikleri.Take(6).Sum(), y);
                e.Graphics.DrawString(danisman, icerikFont, Brushes.Black, sayfaAyarları.Margins.Left + sutunGenislikleri.Take(7).Sum(), y);

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
