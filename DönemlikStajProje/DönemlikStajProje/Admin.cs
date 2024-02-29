using DönemlikStajProje.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DönemlikStajProje
{
    public partial class Admin : Form
    {
        private Data.Admin _admin;

        public Admin(Data.Admin admin)
        {
            InitializeComponent();
            _admin = admin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.Filter = "Png Dosyaları|*.png";
            filedialog.FilterIndex = 1;
            filedialog.RestoreDirectory = true;
            filedialog.CheckFileExists = true;
            filedialog.Title = "Resim Seçiniz";

            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosyanın adını al
                string filePath = filedialog.FileName;

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

        private void okulBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OkulBİlgileri git=new OkulBİlgileri();
            git.Show();
        }

        private void öğretmenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ögretmen_esg git = new ögretmen_esg();
            git.Show();
        }

        private void öğrenciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ögrenci_esg git = new Ögrenci_esg();
            git.Show();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerEkle git= new PerEkle();
            git.Show();
        }

        private void dersEkleSilGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DersİSlemleri git=new DersİSlemleri();
            git.Show();
        }

        private void bölümEkleSilGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bölüm git=new Bölüm();
            git.Show();
        }

        private void duyuruEkleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Duyuru_Ekle git=new Duyuru_Ekle(adı);
            git.Show();
        }

        private void sınavSonuçlarıToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sınav_Sonuc git=new Sınav_Sonuc();
            git.Show();
        }

        private void duyuruEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Duyuru_Listele git=new Duyuru_Listele();
            git.Show();
        }

        private void öğrenciİstatistikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ogr_İstatistik git=new Ogr_İstatistik();
            git.Show();
        }
        string adı;
        private void Admin_Load(object sender, EventArgs e)
        {
             adı= _admin.adminIsim;
            string filePath = _admin.adminFotoYolu;
            ad.Text = _admin.adminIsim;
            Soyad.Text=_admin.adminSoyad;
            EPosta.Text=_admin.adminEposta;
          
            Image originalImage = Image.FromFile(filePath);

            // PictureBox'ın boyutlarını al
            int pictureBoxWidth = pictureBox1.Width;
            int pictureBoxHeight = pictureBox1.Height;

            // Resmi PictureBox'ın boyutlarına uygun olarak ölçekle
            Image boyutlandır = ResizeImage(originalImage, pictureBoxWidth, pictureBoxHeight);

            // PictureBox'a ölçeklenmiş resmi ata
            pictureBox1.Image = boyutlandır;
            ID.Text = _admin.adminId.ToString();
            timer1.Start();
            MessageBox.Show(_admin.adminIsim + " " + _admin.adminSoyad.ToUpper(), "Sisteme Tekrar Hoşgeldiniz");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Close();
            Giriş git =new Giriş();
            git.Show();
        }
        Context db= new Context();  
        Data.Admin admin1 = new Data.Admin();
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
            _admin.adminFotoYolu = uzantı.Text;
            db.SaveChanges();
            uzantı.Visible = false;
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
        Kullanıcı k = new Kullanıcı();
        private void şifreİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k.Ad = ad.Text;
            k.Soyad = Soyad.Text;
            k.Yetki = "Admin";
            k.Id = ID.Text;
            ŞifreDeğiştir git = new ŞifreDeğiştir(k);
            git.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            SendKeys.Send("{ESC}");
        }

        private void mailGöndermeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mail_Gönderme git=new Mail_Gönderme();
            git.Show();
        }

        private void duyularToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
