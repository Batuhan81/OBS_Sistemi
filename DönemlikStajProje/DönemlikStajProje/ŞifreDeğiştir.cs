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
    public partial class ŞifreDeğiştir : Form
    {

        private Kullanıcı _kisi;
        public ŞifreDeğiştir(Kullanıcı kisi)
        {
            InitializeComponent();
            _kisi = kisi;
        }

        private void ŞifreDeğiştir_Load(object sender, EventArgs e)
        {
            ad.Text = _kisi.Ad;
            soyad.Text = _kisi.Soyad;
            yetki.Text = _kisi.Yetki;
            ID.Text = _kisi.Id;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ID.Text);
            EskiKontrol(eski.Text);
            EslesmeKontrol();
            if (eskisifre == eski.Text)
            {
                if (eslesti == true)
                {
                    if (yetki.Text == "Admin")
                    {
                        var x = db.Adminler.Find(id);
                        x.adminParola = yeni.Text;
                    }
                    if (yetki.Text == "Prof")
                    {
                        var x = db.Profesorler.Find(id);
                        x.profesorParola = yeni.Text;
                    }
                    if (yetki.Text == "Öğrenci")
                    {
                        var x = db.Ogrenciler.Find(id);
                        x.ogrenciParola = yeni.Text;
                    }
                }
                db.SaveChanges();
                eslesti = false;
            }
        }
        Context db = new Context();
        bool eslesti = false;
        void EslesmeKontrol()
        {
            if (yeni.Text == yenitekrar.Text)
            {
                eslesti = true;
            }
            else
            {
                eslesti = false;
            }
        }

        string eskisifre;
        string EskiKontrol(string sifre)
        {
            int ıd =Convert.ToInt32( ID.Text);
            if (yetki.Text == "Prof")
            {
                eskisifre = (from Profesor in db.Profesorler
                             where Profesor.profesorId == ıd
                             select Profesor.profesorParola).FirstOrDefault();
            }

            if (yetki.Text == "Admin")
            {
                eskisifre = (from Admin in db.Adminler
                             where Admin.adminId == ıd
                             select Admin.adminParola).FirstOrDefault();
            }
            if (yetki.Text == "Öğrenci")
            {
                eskisifre = (from ogrenci in db.Ogrenciler
                             where ogrenci.ogrenciId == ıd
                             select ogrenci.ogrenciParola).FirstOrDefault();
            }
            return eskisifre;
        }
    }
}
