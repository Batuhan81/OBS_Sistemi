using DönemlikStajProje.Data;
using Mysqlx.Crud;
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
    public partial class Notlarım : Form
    {
        private string _ogrAdi;
        public Notlarım(string ogrAdi)
        {
            InitializeComponent();
            _ogrAdi = ogrAdi;
        }

        private void Notlarım_Load(object sender, EventArgs e)
        {
            ad.Text= _ogrAdi;
            comboDersDoldur();
            comboDers.SelectedIndex = 0;
            Listele();
        }
        Context db=new Context();
        void comboDersDoldur()
        {
            comboDers.Items.Clear();
            // Tüm dersleri veritabanından al
            var tumDersler = db.Dersler.ToList();

            // ComboBox'a ders isimlerini yükle
            foreach (var ders in tumDersler)
            {
                comboDers.Items.Add(ders.dersIsim);
         
            }
        }

        private void comboDers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {
            // Seçilen dersin adını al
            string secilenDers = comboDers.SelectedItem.ToString();

            // Öğrencinin adını al
            string ogrenciAdi = ad.Text; // Öğrenci adını girdiği metin kutusu

            // Seçilen dersin ve öğrencinin adına göre notları filtrele
            var query = from ogrenci in db.Ogrenciler
                        join ogrenciDers in db.OgrenciDersler on ogrenci.ogrenciId equals ogrenciDers.ogrenciId
                        join ders in db.Dersler on ogrenciDers.dersId equals ders.dersId
                        where ogrenci.ogrenciIsim == ogrenciAdi && ders.dersIsim == secilenDers // Sadece seçilen dersin ve öğrencinin notlarını al
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

        private void gridOgrenci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboDers.Text = gridOgrenci.CurrentRow.Cells["Ders_Adı"].Value.ToString();
            not1.Text = gridOgrenci.CurrentRow.Cells["Not1"].Value.ToString();
            not2.Text = gridOgrenci.CurrentRow.Cells["Not2"].Value.ToString();
            txtort.Text = gridOgrenci.CurrentRow.Cells["Ortalama"].Value.ToString();
        }
    }
}
