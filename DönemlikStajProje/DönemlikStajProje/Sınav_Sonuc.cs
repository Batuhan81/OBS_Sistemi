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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DönemlikStajProje
{
    public partial class Sınav_Sonuc : Form
    {
        public Sınav_Sonuc()
        {
            InitializeComponent();
        }
        Context db=new Context();
        OgrenciDers snv = new OgrenciDers();
        private void Sınav_Sonuc_Load(object sender, EventArgs e)
        {
            ListeleOgrenciDersleri();
            ComboDersDoldur();
            ComboOgrenciDoldur();
        }

        private void ComboDersDoldur()
        {
            comboDers.Items.Clear();
            // Tüm dersleri veritabanından al
            var tumDersler = db.Dersler.ToList();

            // ComboBox'a ders isimlerini yükle
            foreach (var ders in tumDersler)
            {
                comboDers.Items.Add(ders.dersIsim);
                dersfiltre.Items.Add(ders.dersIsim);
            }
        }
        private void ComboOgrenciDoldur()
        {
            // Tüm dersleri veritabanından al
            var tumDersler = db.Ogrenciler.ToList();

            // ComboBox'a ders isimlerini yükle
            foreach (var ders in tumDersler)
            {
                comboÖgrenci.Items.Add(ders.ogrenciIsim);
                ogrfiltre.Items.Add(ders.ogrenciIsim);
            }
        }

        private void ListeleOgrenciDersleri()
        {
            var query = from ogrenci in db.Ogrenciler
                        join ogrenciDers in db.OgrenciDersler on ogrenci.ogrenciId equals ogrenciDers.ogrenciId
                        join ders in db.Dersler on ogrenciDers.dersId equals ders.dersId
                        select new
                        {
                            ID= ogrenciDers.ogrenciDersId,
                            Öğrenci_Adı = ogrenci.ogrenciIsim,
                            Ders_Adı = ders.dersIsim,
                            Not1 = ogrenciDers.dersSinavSonuc1,
                            Not2 = ogrenciDers.dersSinavSonuc2,
                            Ortalama = ogrenciDers.dersFinalSonuc,
                        };

            gridOgrenci.DataSource = query.ToList();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (ogrDers.Text=="")
            {
                snv.dersId = Convert.ToInt32(hiddenDersID.Text);
                snv.ogrenciId = Convert.ToInt32(hiddenOGrID.Text);
                snv.dersSinavSonuc1 = s1;
                snv.dersSinavSonuc2 = s2;
                snv.dersFinalSonuc = Convert.ToInt32(ort);
                snv.olusturmaTarihi = DateTime.Now;
                db.OgrenciDersler.Add(snv);
                timer1.Start();
                MessageBox.Show("Kayıt İşlemi Başarılı");

            }
            else
            {
                int id = Convert.ToInt32(ogrDers.Text);
                var x = db.OgrenciDersler.Find(id);
                x.dersId = Convert.ToInt32(hiddenDersID.Text);
                x.ogrenciId = Convert.ToInt32(hiddenOGrID.Text);
                x.dersSinavSonuc1 = s1;
                x.dersSinavSonuc2 = s2;
                x.dersFinalSonuc = Convert.ToInt32(ort);
                x.olusturmaTarihi = DateTime.Now;
                timer1.Start();
                MessageBox.Show("Güncelleme İşlemi Başarılı");
            }
            db.SaveChanges();
            ListeleOgrenciDersleri();
            Temizle();
        }
        void Temizle()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if(item is TextBox)
                {
                    item.Text="";
                }

                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
            ogrDers.Text = "";
            hiddenNotID.Text = "";
            hiddenOGrID.Text = "";
        }

        private void comboDers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen dersin adını al
            string secilenDersAdi = comboDers.SelectedItem.ToString();

            // Ders adına göre id'sini bul
            var secilenDers = db.Dersler.FirstOrDefault(d => d.dersIsim == secilenDersAdi);

            if (secilenDers != null)
            {
                // Ders id'sini TextBox'a ata
                hiddenDersID.Text = secilenDers.dersId.ToString();
            }
            else
            {
                // Ders bulunamadıysa TextBox'ı boş bırak
                hiddenDersID.Text = "";
            }
        }

        private void comboDers_TextChanged(object sender, EventArgs e)
        {
            
        }

        string secilenOgrAd;
        private void comboÖgrenci_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen dersin adını al
            secilenOgrAd = comboÖgrenci.SelectedItem.ToString();


            // Ders adına göre id'sini bul
            var secilenDers = db.Ogrenciler.FirstOrDefault(d => d.ogrenciIsim == secilenOgrAd);

            if (secilenDers != null)
            {
                // Ders id'sini TextBox'a ata
                hiddenOGrID.Text = secilenDers.ogrenciId.ToString();
            }
            else
            {
                // Ders bulunamadıysa TextBox'ı boş bırak
                hiddenOGrID.Text = "";
            }
        }
        int s1, s2;
        double ort;
        
        private void gridOgrenci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboDers.Text = gridOgrenci.CurrentRow.Cells["Ders_Adı"].Value.ToString();
            comboÖgrenci.Text = gridOgrenci.CurrentRow.Cells["Öğrenci_Adı"].Value.ToString();
            not1.Text = gridOgrenci.CurrentRow.Cells["Not1"].Value.ToString();
            not2.Text = gridOgrenci.CurrentRow.Cells["Not2"].Value.ToString();
            txtort.Text = gridOgrenci.CurrentRow.Cells["Ortalama"].Value.ToString();
            ogrDers.Text = gridOgrenci.CurrentRow.Cells["ID"].Value.ToString();
        }

        private void ogrfiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seçim = ogrfiltre.SelectedItem.ToString();

            if (seçim == "Tümü")
            {
                var query = from ogrenci in db.Ogrenciler
                            join ogrenciDers in db.OgrenciDersler on ogrenci.ogrenciId equals ogrenciDers.ogrenciId
                            join ders in db.Dersler on ogrenciDers.dersId equals ders.dersId
                            select new
                            {
                                ID = ogrenciDers.ogrenciDersId,
                                Öğrenci_Adı = ogrenci.ogrenciIsim,
                                Ders_Adı = ders.dersIsim,
                                Not1 = ogrenciDers.dersSinavSonuc1,
                                Not2 = ogrenciDers.dersSinavSonuc2,
                                Ortalama = ogrenciDers.dersFinalSonuc,
                            };

                gridOgrenci.DataSource = query.ToList();
            }
            else
            {
                var query = from ogrenci in db.Ogrenciler
                            join ogrenciDers in db.OgrenciDersler on ogrenci.ogrenciId equals ogrenciDers.ogrenciId
                            join ders in db.Dersler on ogrenciDers.dersId equals ders.dersId
                            where ogrenci.ogrenciIsim == seçim
                            select new
                            {
                                ID = ogrenciDers.ogrenciDersId,
                                Öğrenci_Adı = ogrenci.ogrenciIsim,
                                Ders_Adı = ders.dersIsim,
                                Not1 = ogrenciDers.dersSinavSonuc1,
                                Not2 = ogrenciDers.dersSinavSonuc2,
                                Ortalama = ogrenciDers.dersFinalSonuc,
                            };

                gridOgrenci.DataSource = query.ToList();
            }
        }
      
        private void dersfiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seçim=dersfiltre.SelectedItem.ToString();
            if (seçim == "Tümü")
            {
                var query = from ogrenci in db.Ogrenciler
                            join ogrenciDers in db.OgrenciDersler on ogrenci.ogrenciId equals ogrenciDers.ogrenciId
                            join ders in db.Dersler on ogrenciDers.dersId equals ders.dersId
                            select new
                            {
                                ID = ogrenciDers.ogrenciDersId,
                                Öğrenci_Adı = ogrenci.ogrenciIsim,
                                Ders_Adı = ders.dersIsim,
                                Not1 = ogrenciDers.dersSinavSonuc1,
                                Not2 = ogrenciDers.dersSinavSonuc2,
                                Ortalama = ogrenciDers.dersFinalSonuc,
                            };

                gridOgrenci.DataSource = query.ToList();
            }
            else
            {
                var query = from ogrenci in db.Ogrenciler
                            join ogrenciDers in db.OgrenciDersler on ogrenci.ogrenciId equals ogrenciDers.ogrenciId
                            join ders in db.Dersler on ogrenciDers.dersId equals ders.dersId
                            where ders.dersIsim == seçim
                            select new
                            {
                                ID = ogrenciDers.ogrenciDersId,
                                Öğrenci_Adı = ogrenci.ogrenciIsim,
                                Ders_Adı = ders.dersIsim,
                                Not1 = ogrenciDers.dersSinavSonuc1,
                                Not2 = ogrenciDers.dersSinavSonuc2,
                                Ortalama = ogrenciDers.dersFinalSonuc,
                            };
                gridOgrenci.DataSource = query.ToList();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Stop();
            SendKeys.Send("{ESC}");
        }

        private void txtort_Click(object sender, EventArgs e)
        {
             s1 = Convert.ToInt32(not1.Text);
             s2 = Convert.ToInt32(not2.Text);
             ort = (s1 * 0.4) + (s2 * 0.6);
            txtort.Text = ort.ToString();
        }
    }
}
