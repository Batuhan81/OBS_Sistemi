using DönemlikStajProje.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DönemlikStajProje
{
    public partial class Öğretmen_Paneli : Form
    {
        private Data.Profesor _prof;
        public Öğretmen_Paneli(Data.Profesor prof)
        {
            InitializeComponent();
            _prof = prof;
        }

        private void yönlendirilecekSayflarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void öğrenciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ögrenci_esg git = new Ögrenci_esg();
            git.Show();
        }

        private void duyuruEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Duyuru_Listele git = new Duyuru_Listele();
            git.Show();
        }

        private void duyuruEkleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Duyuru_Ekle git = new Duyuru_Ekle(adı);
            git.Show();
        }

        private void öğrenciİstatistikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ogr_İstatistik git = new Ogr_İstatistik();
            git.Show();
        }

        private void sınavSonuçlarıToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sınav_Sonuc git = new Sınav_Sonuc();
            git.Show();
        }

        private void okulBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OkulBİlgileri git = new OkulBİlgileri();
            git.Show();
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
        string adı;
        private void Öğretmen_Paneli_Load(object sender, EventArgs e)
        {
            string filePath = _prof.profesorFotoYolu;
            adı = _prof.profesorIsim;
            txtad.Text = adı;
            txtsoyad.Text = _prof.profesorSoyad;
            txtposta.Text = _prof.profesorEposta;
          
            Image originalImage = Image.FromFile(filePath);

            // PictureBox'ın boyutlarını al
            int pictureBoxWidth = pictureBox1.Width;
            int pictureBoxHeight = pictureBox1.Height;

            // Resmi PictureBox'ın boyutlarına uygun olarak ölçekle
            Image boyutlandır = ResizeImage(originalImage, pictureBoxWidth, pictureBoxHeight);

            // PictureBox'a ölçeklenmiş resmi ata
            pictureBox1.Image = boyutlandır;
            ID.Text=_prof.profesorId.ToString();
            timer1.Start();
            MessageBox.Show(_prof.profesorIsim + " " + _prof.profesorSoyad.ToUpper(), "Sisteme Hoşgeldiniz");
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
        Kullanıcı k=new Kullanıcı();
        private void şifreDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k.Ad = ad.Text;
            k.Soyad=Soyad.Text;
            k.Yetki = "Prof";
            k.Id = label4.Text;
            
            ŞifreDeğiştir git=new ŞifreDeğiştir(k);
            git.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            SendKeys.Send("{ESC}");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Giriş git=new Giriş();
            git.Show();
        }

        private void button2_Click(object sender, EventArgs e)
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
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Ogrenci_Paneli.DersProgİndir();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Ogrenci_Paneli.SınavTarihiİndir();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Ogrenci_Paneli.AkademikTİndir();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
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
