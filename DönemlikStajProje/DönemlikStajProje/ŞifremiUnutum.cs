using DönemlikStajProje.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DönemlikStajProje
{
    public partial class ŞifremiUnutum : Form
    {
        public ŞifremiUnutum()
        {
            InitializeComponent();
        }
        string email;
        private void button1_Click(object sender, EventArgs e)
        {
             email=txtmail.Text;
            SifreGonder(email);
            MessageBox.Show("Yeni Şifreniz Mail Yolu İle İletilmiştir Lütfen Kontrol Edininiz...");
        }
        Context db=new Context();
        void SifreGonder(string a)
        {
            Kullanici kullanici = VeritabanindanKullaniciBul(email);
            if(kullanici == null)
            {
                MessageBox.Show("Girdiğiniz E-Posta Adresi Veritabanımızda Kayıtlı Değil Lütfen Yetkili Kişiyle İletişime Geçiniz");
            }
            else
            {
                if (kullanici.Rol == "Öğrenci")
                {
                    // Yeni random şifre oluştur
                    string yeniSifre = RandomSifreOlustur(8);

                    // Yeni şifreyi kullanıcının e-posta adresine gönder
                    EpostaGonder(email, yeniSifre);

                    // Kullanıcının şifresini güncelle
                    SifreyiGuncelle(email, yeniSifre);

                    Console.WriteLine("Yeni şifre e-posta adresinize gönderildi.");
                }
                else if(kullanici.Rol == "Profesor")
                {
                    // Yeni random şifre oluştur
                    string yeniSifre = RandomSifreOlustur(8);

                    // Yeni şifreyi kullanıcının e-posta adresine gönder
                    EpostaGonder(email, yeniSifre);

                    // Kullanıcının şifresini güncelle
                    SifreyiGuncelle(email, yeniSifre);

                    Console.WriteLine("Yeni şifre e-posta adresinize gönderildi.");
                }
                else if (kullanici.Rol == "Admin")
                {
                    // Yeni random şifre oluştur
                    string yeniSifre = RandomSifreOlustur(8);

                    // Yeni şifreyi kullanıcının e-posta adresine gönder
                    EpostaGonder(email, yeniSifre);

                    // Kullanıcının şifresini güncelle
                    SifreyiGuncelle(email, yeniSifre);

                    Console.WriteLine("Yeni şifre e-posta adresinize gönderildi.");
                }
                
            }
        }
        // Yeni bir random şifre oluştur
        public static string RandomSifreOlustur(int uzunluk)
        {
            const string karakterler = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < uzunluk; i++)
            {
                int index = rnd.Next(karakterler.Length);
                sb.Append(karakterler[index]);
            }
            return sb.ToString();
        }
        // Kullanıcı şifresini güncelleme işlevi
        public void SifreyiGuncelle(string email, string yeniSifre)
        {
            var ogrenci = db.Ogrenciler.FirstOrDefault(o => o.ogrenciEposta == email);
            var profesor = db.Profesorler.FirstOrDefault(p => p.profesorEposta == email);
            var admin = db.Adminler.FirstOrDefault(a => a.adminEposta == email);

            if (ogrenci != null)
            {
                ogrenci.ogrenciParola = yeniSifre;
            }
            else if (profesor != null)
            {
                profesor.profesorParola = yeniSifre;
            }
            else if (admin != null)
            {
                admin.adminParola = yeniSifre;
            }

            db.SaveChanges();
        }




        // E-posta gönderme işlevi
        public static void EpostaGonder(string alici, string yeniSifre)
        {
            string gonderenEposta = "OrtakProje2@outlook.com";
            string gonderenSifre = "Bthn185Prj";
            string konu = "Yeni Şifre";
            string icerik = "Yeni şifreniz: " + yeniSifre;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.office365.com";
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(gonderenEposta, gonderenSifre);

           MailMessage mail = new MailMessage();
            mail.From = new MailAddress(gonderenEposta, "Yeni Şifre Talebi");
            mail.To.Add(alici);
            mail.Subject =konu;
            mail.IsBodyHtml = true;
            mail.Body = icerik;
            smtp.Send(mail);
        }
        private Kullanici VeritabanindanKullaniciBul(string email)
        {
            /// Öğrenci tablosunda kullanıcıyı ara
            var ogrenci = db.Ogrenciler.FirstOrDefault(o => o.ogrenciEposta == email);
            if (ogrenci != null)
            {
                return new Kullanici { Rol = "Öğrenci" };
            }

            // Profesör tablosunda kullanıcıyı ara
            var profesor = db.Profesorler.FirstOrDefault(p => p.profesorEposta == email);
            if (profesor != null)
            {
                return new Kullanici { Rol = "Profesor" };
            }

            // Admin tablosunda kullanıcıyı ara
            var admin = db.Adminler.FirstOrDefault(a => a.adminEposta == email);
            if (admin != null)
            {
                return new Kullanici { Rol = "Admin" };
            }

            return null; // Bulunan kullanıcıyı veya null değerini dönün
        }
    }
}
