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
    public partial class Giriş : Form
    {
        public Giriş()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //yeni bir sayfaya gönderecek burada eğer girdiği mail sistemde kayıtlı olan bir mail ise o maile random oluşturulmuş bir şifre gidecek ve bu yeni şifre veritabanından güncellenecek
            ŞifremiUnutum git = new ŞifremiUnutum();
            git.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtmail.Text;
            string sifre = txtşifre.Text;
            GirisYap(email, sifre);
           
           
        }
        private void GirisYap(string email, string sifre)
        {
            // Kullanıcıyı veritabanında bul
            Kullanici kullanici = VeritabanindanKullaniciBul(email, sifre);

            if (kullanici != null)
            {
                // Kullanıcının rolüne göre yönlendirme yap
                if (kullanici.Rol == "Öğrenci")
                {
                    Data.Ogrenci ogr = db.Ogrenciler.FirstOrDefault(x => x.ogrenciEposta == email && x.ogrenciParola==sifre);
                    Ogrenci_Paneli git= new Ogrenci_Paneli(ogr);
                    git.Show();

                }
                else if (kullanici.Rol == "Profesor")
                {
                    Data.Profesor prof = db.Profesorler.FirstOrDefault(x => x.profesorEposta == email && x.profesorParola == sifre);
                    Öğretmen_Paneli git = new Öğretmen_Paneli(prof);
                    git.Show();
                }
                else if (kullanici.Rol == "Admin")
                {
                    Data.Admin admin = db.Adminler.FirstOrDefault(x => x.adminEposta == email && x.adminParola == sifre);
                    Admin git = new Admin(admin);
                    git.Show();
                }
                txtmail.Text = "";
                txtşifre.Text = "";
            }
            else
            {
                MessageBox.Show("Geçersiz e-posta veya şifre.","Giriş Başarısız",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            this.Close();
        }
        Context db=new Context();
        private Kullanici VeritabanindanKullaniciBul(string email, string sifre)
        {
            /// Öğrenci tablosunda kullanıcıyı ara
            var ogrenci = db.Ogrenciler.FirstOrDefault(o => o.ogrenciEposta == email && o.ogrenciParola == sifre);
            if (ogrenci != null)
            {
                return new Kullanici { Rol = "Öğrenci" };
            }

            // Profesör tablosunda kullanıcıyı ara
            var profesor = db.Profesorler.FirstOrDefault(p => p.profesorEposta == email && p.profesorParola == sifre);
            if (profesor != null)
            {
                return new Kullanici { Rol = "Profesor" };
            }

            // Admin tablosunda kullanıcıyı ara
            var admin = db.Adminler.FirstOrDefault(a => a.adminEposta == email && a.adminParola == sifre);
            if (admin != null)
            {
                return new Kullanici { Rol = "Admin" };
            }

            return null; // Bulunan kullanıcıyı veya null değerini dönün
        }

        private void Giriş_Load(object sender, EventArgs e)
        {
            txtmail.Focus();
        }
    }
}
