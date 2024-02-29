using DönemlikStajProje.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DönemlikStajProje
{
    public partial class Ogrenci_Paneli : Form
    {
        private Data.Ogrenci _ogr;
        public Ogrenci_Paneli(Data.Ogrenci ogr)
        {
            InitializeComponent();
            _ogr = ogr;
        }
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
        private void Ogrenci_Paneli_Load(object sender, EventArgs e)
        {
            int bolumId = _ogr.ogrenciBolum;
             string filePath = _ogr.OgrenciFotoYolu;
            ad.Text = _ogr.ogrenciIsim;
            var bolum = db.Bolumler.FirstOrDefault(b => b.bolumId == bolumId);
            txtbölüm.Text = bolum.bolumIsim;
            Soyad.Text = _ogr.ogrenciSoyad;
            EPosta.Text = _ogr.ogrenciEposta;
           
            Image originalImage = Image.FromFile(filePath);

            // PictureBox'ın boyutlarını al
            int pictureBoxWidth = pictureBox1.Width;
            int pictureBoxHeight = pictureBox1.Height;

            // Resmi PictureBox'ın boyutlarına uygun olarak ölçekle
            Image boyutlandır = ResizeImage(originalImage, pictureBoxWidth, pictureBoxHeight);

            // PictureBox'a ölçeklenmiş resmi ata
            pictureBox1.Image = boyutlandır;
            ID.Text=_ogr.ogrenciId.ToString();
            timer1.Start();
            MessageBox.Show( _ogr.ogrenciIsim + " " + _ogr.ogrenciSoyad.ToUpper(), "Sisteme Tekrar Hoşgeldiniz");
        }

        private void sınavSonuçlarıToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Notlarım git =new Notlarım(_ogr.ogrenciIsim);
            git.Show();
        }

        private void okulBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OkulBİlgileri git =new OkulBİlgileri();
            git.Show();
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
        Data.Context db= new Data.Context();
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
            _ogr.OgrenciFotoYolu = uzantı.Text;
            db.SaveChanges();
            uzantı.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Giriş git = new Giriş();
            this.Close();
            git.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DersProgİndir();
        }

        public static void DersProgİndir()
        {
            Data.Context db= new Data.Context();
            try
            {
                // Duyurular içerisinde başlığı "Ders Programı" olan ve aktif olan dosyanın yolunu al
                var dersProgramiDuyurular = db.Duyurular.FirstOrDefault(d => d.duyuruBaslik == "Ders Programı" && d.duyuruBelgeYolu != null && d.duyuruAktifmi == true); // aktif durumu 1 olanları al

                // Ders programı duyurusu bulundu mu kontrol et ve aktifse indirme işlemini yap
                if (dersProgramiDuyurular != null && dersProgramiDuyurular.duyuruAktifmi == true)
                {
                    // Dosya yolu boş değilse devam et
                    string dosyaYolu = dersProgramiDuyurular.duyuruBelgeYolu;

                    // Dosyayı indirmek için bir SaveFileDialog oluşturun
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.FileName = Path.GetFileName(dosyaYolu); // İndirilen dosyanın adını ayarlayın
                    saveDialog.Filter = "Tüm Dosyalar (*.*)|*.*"; // Tüm dosya türlerini filtreleyin

                    // Kullanıcı dosya kaydetmek için bir konum seçene kadar bekleyin
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Dosyayı indirme işlemi
                        File.Copy(dosyaYolu, saveDialog.FileName, true);
                        MessageBox.Show("Dosya başarıyla indirildi!");
                    }
                }
                else
                {
                    MessageBox.Show("Ders programı Henüz Hazır Değil Lütfen Beklemede Kalınız!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya indirme sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SınavTarihiİndir();
        }

        public static void SınavTarihiİndir()
        {
            Data.Context db=new Data.Context();
            try
            {
                var dersProgramiDuyurular = db.Duyurular.FirstOrDefault(d => d.duyuruBaslik == "Sınav Tarihleri" && d.duyuruBelgeYolu != null && d.duyuruAktifmi == true); // aktif durumu 1 olanları al
                if (dersProgramiDuyurular != null && dersProgramiDuyurular.duyuruAktifmi == true)
                {
                    // Dosya yolu boş değilse devam et
                    string dosyaYolu = dersProgramiDuyurular.duyuruBelgeYolu;

                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.FileName = Path.GetFileName(dosyaYolu); // İndirilen dosyanın adını ayarlayın
                    saveDialog.Filter = "Tüm Dosyalar (*.*)|*.*"; // Tüm dosya türlerini filtreleyin

                    // Kullanıcı dosya kaydetmek için bir konum seçene kadar bekleyin
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Dosyayı indirme işlemi
                        File.Copy(dosyaYolu, saveDialog.FileName, true);
                        MessageBox.Show("Dosya başarıyla indirildi!");
                    }
                }
                else
                {
                    MessageBox.Show("Sınav Tarihleri Henüz Belli Değil Lütfen Beklemede Kalınız!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya indirme sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private void sınavTarihleriToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                // Veritabanından "Ders Programı" başlığına sahip dosya yolunu al
                var dersProgrami = db.Duyurular.FirstOrDefault(d => d.duyuruBaslik == "Sınav Tarihleri" && d.duyuruBelgeYolu != null && d.duyuruAktifmi == true);

                if (dersProgrami != null)
                {
                    // Dosya yolu boş değilse devam et
                    string dosyaYolu = dersProgrami.duyuruBelgeYolu;

                    WebBrowser webBrowser = new WebBrowser();
                    webBrowser.Dock = DockStyle.Fill;
                    webBrowser.Navigate(dosyaYolu);

                }
                else
                {
                    MessageBox.Show("Sınav Tarihleri Henüz Belli Değil Beklemede Kalınız!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ders programı gösterme sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private void dersProgramıToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                // Veritabanından "Ders Programı" başlığına sahip dosya yolunu al
                var dersProgrami = db.Duyurular.FirstOrDefault(d => d.duyuruBaslik == "Ders Programı" && d.duyuruBelgeYolu != null && d.duyuruAktifmi == true);

                if (dersProgrami != null)
                {
                    // Dosya yolu boş değilse devam et
                    string dosyaYolu = dersProgrami.duyuruBelgeYolu;

                    WebBrowser webBrowser = new WebBrowser();
                    webBrowser.Dock = DockStyle.Fill;
                    webBrowser.Navigate(dosyaYolu);
                }
                else
                {
                    MessageBox.Show("Ders Programı Henüz Hazır Değil Lütfen Beklemede Kalınız!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ders programı gösterme sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private void duyuruEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Duyuru_Listele git=new Duyuru_Listele();
            git.Show();
        }
        Kullanıcı k=new Kullanıcı();
        private void şifreDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k.Ad = ad.Text;
            k.Soyad=Soyad.Text;
            k.Yetki = "Öğrenci";
            k.Id = ID.Text;
            ŞifreDeğiştir git = new ŞifreDeğiştir(k);
            git.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            SendKeys.Send("{ESC}");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AkademikTİndir();
        }

        public static void AkademikTİndir()
        {
            Data.Context db= new Data.Context();
            try
            {
                var dersProgramiDuyurular = db.Duyurular.FirstOrDefault(d => d.duyuruBaslik == "Akademik Takvim" && d.duyuruBelgeYolu != null && d.duyuruAktifmi == true); // aktif durumu 1 olanları al
                if (dersProgramiDuyurular != null && dersProgramiDuyurular.duyuruAktifmi == true)
                {
                    string dosyaYolu = dersProgramiDuyurular.duyuruBelgeYolu;
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.FileName = Path.GetFileName(dosyaYolu); // İndirilen dosyanın adını ayarlayın
                    saveDialog.Filter = "Tüm Dosyalar (*.*)|*.*"; // Tüm dosya türlerini filtreleyin

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Dosyayı indirme işlemi
                        File.Copy(dosyaYolu, saveDialog.FileName, true);
                        MessageBox.Show("Dosya başarıyla indirildi!");
                    }
                }
                else
                {
                    MessageBox.Show("Akademik Takvim Henüz Belli Değil Lütfen Beklemede Kalınız!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya indirme sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private void akademikTakvimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Veritabanından "Ders Programı" başlığına sahip dosya yolunu al
                var dersProgrami = db.Duyurular.FirstOrDefault(d => d.duyuruBaslik == "Akademik Takvim" && d.duyuruBelgeYolu != null && d.duyuruAktifmi == true);

                if (dersProgrami != null)
                {
                    string dosyaYolu = dersProgrami.duyuruBelgeYolu;
                    WebBrowser webBrowser = new WebBrowser();
                    webBrowser.Dock = DockStyle.Fill;
                    webBrowser.Navigate(dosyaYolu);
                }
                else
                {
                    MessageBox.Show("Akademik Takvim Henüz Hazır Değil Lütfen Beklemede Kalınız!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ders programı gösterme sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private void mesajlaşmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.Ogrenci ogr = db.Ogrenciler.FirstOrDefault(x => x.ogrenciIsim==ad.Text);
            Mesajlaşma git=new Mesajlaşma(ogr);
            git.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                linkLabel1.Visible = true;
                linkLabel2.Visible = true;
                linkLabel3.Visible = true;
            }
            else
            {
                linkLabel1.Visible = false;
                linkLabel2.Visible = false;
                linkLabel3.Visible = false;
            }
        }
    }
}
