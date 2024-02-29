using DönemlikStajProje.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DönemlikStajProje
{
    public partial class Mail_Gönderme : Form
    {
        public Mail_Gönderme()
        {
            InitializeComponent();
        }

        private void Mail_Gönderme_Load(object sender, EventArgs e)
        {
            comboDoldur();
        }
        Context db = new Context();
        void comboDoldur()
        {
            // Tüm dersleri veritabanından al
            var tumogrenciler = db.Ogrenciler.ToList();

            // ComboBox'a ders isimlerini yükle
            foreach (var ogrenci in tumogrenciler)
            {
                alan.Items.Add(ogrenci.ogrenciIsim);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || birey!=null)
            {
                // Eğer bir checkbox seçildiyse
                string icerik = txtİçerik.Text;
                string konu = txtkonu.Text;

                List<string> alicilar = new List<string>();

                if (checkBox1.Checked) // İlk checkbox seçiliyse
                {
                    // Öğrencilerin ve profesörlerin e-posta adreslerini al
                    var ogrenciEpostalar = db.Ogrenciler.Select(x => x.ogrenciEposta).ToList();
                    var profesorEpostalar = db.Profesorler.Select(x => x.profesorEposta).ToList();
                    alicilar.AddRange(ogrenciEpostalar);
                    alicilar.AddRange(profesorEpostalar);
                }

                if (checkBox2.Checked) // İkinci checkbox seçiliyse
                {
                    // Profesörlerin e-posta adreslerini al
                    var profesorEpostalar = db.Profesorler.Select(x => x.profesorEposta).ToList();
                    alicilar.AddRange(profesorEpostalar);
                }

                if (checkBox3.Checked) // Üçüncü checkbox seçiliyse
                {
                    // Öğrencilerin e-posta adreslerini al
                    var ogrenciEpostalar = db.Ogrenciler.Select(x => x.ogrenciEposta).ToList();
                    alicilar.AddRange(ogrenciEpostalar);
                }
                if (birey != null)
                {
                    alicilar.Add(birey);
                }

                // Alıcılar listesindeki her bir e-posta adresine mesaj gönder
                foreach (var alici in alicilar)
                {
                    EpostaGonder(alici, icerik, konu);
                }

                MessageBox.Show("E-postalar gönderildi.");
            }
            else
            {
                MessageBox.Show("Lütfen bir alıcı seçin.");
            }
        }

        List<string> ekDosyalar = new List<string>();

        public  void EpostaGonder(string alici, string İçerik, string Konu)
        {
            string gonderenEposta = "OrtakProje2@outlook.com";
            string gonderenSifre = "Bthn185Prj";

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.office365.com";
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(gonderenEposta, gonderenSifre);

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(gonderenEposta, Konu);
            mail.To.Add(alici);
            mail.IsBodyHtml = true;
            mail.Body = İçerik;

            // Ek dosyaları ekle
            foreach (var dosya in ekDosyalar)
            {
                mail.Attachments.Add(new Attachment(dosya));
            }

            smtp.Send(mail);
        }
       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false; checkBox3.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false; checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false; checkBox2.Checked = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosyaDialog = new OpenFileDialog();
            dosyaDialog.Multiselect = true; // Birden fazla dosya seçilebilir
            dosyaDialog.Filter = "Tüm Dosyalar|*.*"; // Filtrelemeyi istediğiniz dosya türleri

            if (dosyaDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string dosyaYolu in dosyaDialog.FileNames)
                {
                    // Seçilen dosyaları listeye ekleyin
                    ekDosyalar.Add(dosyaYolu);
                }
            }
        }
        string birey;
        private void alan_SelectedIndexChanged(object sender, EventArgs e)
        {
            var kisi=db.Ogrenciler.Where(x=>x.ogrenciIsim==alan.Text ).FirstOrDefault();
            birey=kisi.ogrenciEposta.ToString();
        }
    }
}
