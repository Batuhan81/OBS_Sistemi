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
    public partial class Ogr_İstatistik : Form
    {
        public Ogr_İstatistik()
        {
            InitializeComponent();
        }

        private void Ogr_İstatistik_Load(object sender, EventArgs e)
        {
            ListeleOgrenciDersleri();
            BölümDoldur();
        }
        void BölümDoldur()
        {
            // Tüm dersleri veritabanından al
            var tumDersler = db.Bolumler.ToList();

            // ComboBox'a ders isimlerini yükle
            foreach (var ders in tumDersler)
            {
                bolümara.Items.Add(ders.bolumIsim);
            }
        }
        Context db=new Context();
        private void ListeleOgrenciDersleri()
        {
            var query = from ogrenci in db.Ogrenciler
                        join ogrenciDers in db.OgrenciDersler on ogrenci.ogrenciId equals ogrenciDers.ogrenciId
                        join ders in db.Dersler on ogrenciDers.dersId equals ders.dersId
                        select new
                        {
                            Öğrenci_Adı = ogrenci.ogrenciIsim,
                            Ders_Adı = ders.dersIsim,
                            Not1 = ogrenciDers.dersSinavSonuc1,
                            Not2 = ogrenciDers.dersSinavSonuc2,
                            Ortalama = ogrenciDers.dersFinalSonuc,
                        };

            gridOgrenci.DataSource = query.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                var query = from ogrenci in db.Ogrenciler
                            join ogrenciDers in db.OgrenciDersler on ogrenci.ogrenciId equals ogrenciDers.ogrenciId
                            join ders in db.Dersler on ogrenciDers.dersId equals ders.dersId
                            select new
                            {
                                Öğrenci_Adı = ogrenci.ogrenciIsim,
                                Ders_Adı = ders.dersIsim,
                                Not1 = ogrenciDers.dersSinavSonuc1,
                                Not2 = ogrenciDers.dersSinavSonuc2,
                                Ortalama = ogrenciDers.dersFinalSonuc,
                            };

                if (radioButton1.Checked)
                {
                    query = query.OrderBy(x => x.Öğrenci_Adı);
                }
                if (radioButton2.Checked)
                {
                    query = query.OrderByDescending(x => x.Öğrenci_Adı);
                }
                if (radioButton3.Checked)
                {
                    var ortalama = query.Average(p => p.Not1);
                    MessageBox.Show("1. Sınav not Ortalaması =>" + ortalama);
                }
                if (radioButton4.Checked)
                {
                    var ortalama = query.Average(p => p.Not2);
                    MessageBox.Show("2. Sınav not Ortalaması =>" + ortalama);
                }
                if (radioButton5.Checked)
                {
                    var ortalama = query.Average(p => p.Ortalama);
                    MessageBox.Show("Genel not Ortalaması =>" + ortalama);
                }
                if (radioButton6.Checked)
                {
                    var ortalama2 = query.Average(p => p.Not1);
                    query = query.Where(x => x.Not1 >= ortalama2);
                }
                if (radioButton7.Checked)
                {
                    var ortalama2 = query.Average(p => p.Not1);
                    query = query.Where(x => x.Not1 < ortalama2);
                }
                if (radioButton8.Checked)
                {
                    var maxnot = query.Max(p => p.Not1);
                    query = query.Where(x => x.Not1 == maxnot);
                }
                if (radioButton9.Checked)
                {
                    ;
                }
                gridOgrenci.DataSource = query.ToList();
        }
        private void bolümara_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
