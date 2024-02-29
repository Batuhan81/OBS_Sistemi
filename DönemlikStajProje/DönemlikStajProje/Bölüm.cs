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
    public partial class Bölüm : Form
    {
        public Bölüm()
        {
            InitializeComponent();
        }

        Context db = new Context();
        Fakulte f = new Fakulte();
        FakulteBolum fb= new FakulteBolum();
        private void button1_Click(object sender, EventArgs e)
        {
            if (hiddenFakülte.Text == null || hiddenFakülte.Text == "")
            {
                f.fakulteIsim = Fad.Text;
                f.fakulteProfId = Convert.ToInt32(hiddenHoca.Text);
                f.olusturmaTarihi = DateTime.Now;
                db.Fakulteler.Add(f);
                if (hiddenFakülte.Text != "")
                {
                    fb.fakulteId = Convert.ToInt32(hiddenFakülte.Text);

                }
                fb.olusturmaTarihi=DateTime.Now;
                db.FakulteBolumler.Add(fb);
                timer1.Start();
                MessageBox.Show("Kayıt İşlemi Başarılı");
            }
            else
            {
                int id = Convert.ToInt32(hiddenFakülte.Text);
                var x = db.Fakulteler.Find(id);
                x.fakulteIsim = Fad.Text;
                x.fakulteProfId = Convert.ToInt32(hiddenHoca.Text);
                x.olusturmaTarihi = DateTime.Now;
                timer1.Start();
                MessageBox.Show("Güncelleme Başarılı");
            }
            db.SaveChanges();
            FakülteListe();
            Temizle();
            hiddenHoca.Text = "";
            hiddenFakülte.Text = "";
        }
        void FakülteListe()
        {
            var fakulte = db.Fakulteler.ToList().Select(o => new
            {
                ID = o.fakulteId,
                Prof_Adı = db.Profesorler.FirstOrDefault(p => p.profesorId == o.fakulteProfId)?.profesorIsim, // profesör adını al
                Fakülte_Adı = o.fakulteIsim,
                Oluşturulma_Tarihi = o.olusturmaTarihi,
            }).ToList();
            gridFakülte.DataSource = fakulte;
        }
        void BölümListele()
        {
            var bölüm = db.Bolumler.ToList().Select(o => new
            {
                ID = o.bolumId,
                Prof_Adı = db.Profesorler.FirstOrDefault(p => p.profesorId == o.bolumProfId)?.profesorIsim, // profesör adını al
                Bölüm_Adı = o.bolumIsim,
                Oluşturulma_Tarihi = o.olusturmaTarihi,
            }).ToList();
            gridbölüm.DataSource = bölüm;
        }
        void Temizle()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }
        int secilenProfesorId;
        void ComboHocaDoldur()
        {
            // Tüm dersleri veritabanından al
            var tumDersler = db.Profesorler.ToList();

            // ComboBox'a ders isimlerini yükle
            foreach (var ders in tumDersler)
            {
                fHoca.Items.Add(ders.profesorIsim);
                bhoca.Items.Add(ders.profesorIsim);
            }
        }
        string secilelnhocaAd;
        private void fHoca_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilelnhocaAd = fHoca.SelectedItem.ToString();

            var secilenDers = db.Profesorler.FirstOrDefault(d => d.profesorIsim == secilelnhocaAd);

            if (secilenDers != null)
            {
                hiddenHoca.Text = secilenDers.profesorId.ToString();
            }
            else
            {
                hiddenHoca.Text = "";
            }
        }

        private void Bölüm_Load(object sender, EventArgs e)
        {
            FakülteListe();
            BölümListele();
            ComboHocaDoldur();
        }

        private void gridFakülte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gridFakülte.Rows[e.RowIndex];
                string secilenHocaAd = row.Cells["Prof_Adı"].Value.ToString(); // Seçilen hocanın adını al
                int secilenHocaId = db.Profesorler.FirstOrDefault(p => p.profesorIsim == secilenHocaAd)?.profesorId ?? 0; // Hoca adından ID'yi bul
                fHoca.Text = gridFakülte.CurrentRow.Cells["Prof_Adı"].Value.ToString();
                hiddenHoca.Text = secilenHocaId.ToString(); // Bulunan ID'yi gizli alana at
                Fad.Text = row.Cells["Fakülte_Adı"].Value.ToString(); // Fakülte adını al
                hiddenFakülte.Text = gridFakülte.CurrentRow.Cells["ID"].Value.ToString();
            }
        }
        Data.Bolum b = new Data.Bolum();
        private void button2_Click(object sender, EventArgs e)
        {
            if (hiddenBölüm.Text == null || hiddenBölüm.Text == "")
            {
                b.bolumIsim = bAd.Text;
                b.bolumProfId = Convert.ToInt32(hiddenHoca.Text);
                b.olusturmaTarihi = DateTime.Now;
                db.Bolumler.Add(b);
                if (hiddenBölüm.Text != "")
                {
                    fb.bolumId = Convert.ToInt32(hiddenBölüm.Text);
                }
                db.FakulteBolumler.Add(fb);
                timer1.Start();
                MessageBox.Show("Kayıt İşlemi Başarılı");
            }
            else
            {
                int id = Convert.ToInt32(hiddenBölüm.Text);
                var x = db.Bolumler.Find(id);
                x.bolumIsim = bAd.Text;
                x.bolumProfId = Convert.ToInt32(hiddenHoca.Text);
                x.olusturmaTarihi = DateTime.Now;
                timer1.Start();
                MessageBox.Show("Güncelleme Başarılı");
            }
            db.SaveChanges();
            BölümListele();
            Temizle();
            hiddenHoca.Text = "";
            hiddenBölüm.Text = "";
        }

        private void gridbölüm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gridbölüm.Rows[e.RowIndex];
                string secilenHocaAd = row.Cells["Prof_Adı"].Value.ToString(); // Seçilen hocanın adını al
                int secilenHocaId = db.Profesorler.FirstOrDefault(p => p.profesorIsim == secilenHocaAd)?.profesorId ?? 0; // Hoca adından ID'yi bul
                bhoca.Text = gridbölüm.CurrentRow.Cells["Prof_Adı"].Value.ToString();
                hiddenHoca.Text = secilenHocaId.ToString(); // Bulunan ID'yi gizli alana at
                bAd.Text = row.Cells["Bölüm_Adı"].Value.ToString(); // Fakülte adını al
                hiddenBölüm.Text = gridbölüm.CurrentRow.Cells["ID"].Value.ToString();
            }
        }

        private void bhoca_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilelnhocaAd = bhoca.SelectedItem.ToString();

            var secilenDers = db.Profesorler.FirstOrDefault(d => d.profesorIsim == secilelnhocaAd);

            if (secilenDers != null)
            {
                hiddenHoca.Text = secilenDers.profesorId.ToString();
            }
            else
            {
                hiddenHoca.Text = "";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            SendKeys.Send("{ESC}");//ESC tuşuna basılmış gibi çalışıyor
        }
    }
}
