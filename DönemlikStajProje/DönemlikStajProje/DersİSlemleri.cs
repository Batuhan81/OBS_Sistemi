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
    public partial class DersİSlemleri : Form
    {
        public DersİSlemleri()
        {
            InitializeComponent();
            ProfesorleriComboBoxDoldur();
        }
        Context db = new Context();
        Ders a = new Ders();
        private void ProfesorleriComboBoxDoldur()
        {
            // Profesörleri veritabanından al ve combo box'a doldur
            var profesorler = db.Profesorler.ToList();
            cmbProfesorler.DisplayMember = "profesorIsim"; // ComboBox'ta görünecek metin profesör adı olacak
            cmbProfesorler.ValueMember = "profesorId"; // ComboBox'ta saklanacak değer profesör ID'si olacak
            cmbProfesorler.DataSource = profesorler;
        }
        void Temizle()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }
        void DersGöster()
        {
            var Ders = db.Dersler.ToList().Select(o => new
            {
                ID = o.dersId,
                Ders_Adı = o.dersIsim,
                Prof_Ad = db.Profesorler.FirstOrDefault(p => p.profesorId == o.dersProfId)?.profesorIsim, // profesör adını al
                Ders_Kredi = o.dersKredi,
                Ders_Kodu = o.dersKod,
                Ders_Akts = o.dersAkts,
                Oluşturma_Tarihi = o.olusturmaTarihi,
            }).ToList();
            dataGridView1.DataSource = Ders;
        }

        private void DersİSlemleri_Load(object sender, EventArgs e)
        {
            DersGöster();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Kullanıcının girdiği ders adını ve seçtiği profesörün ID'sini al
            string dersAdi = dersad.Text;
            int profesorId = Convert.ToInt32(cmbProfesorler.SelectedValue);
            if (hiddenID.Text == null || hiddenID.Text == "")
            {
                // Ders tablosuna yeni bir ders ekleyin
                Ders yeniDers = new Ders()
                {
                    dersIsim = dersAdi,
                    dersKod = txtkod.Text,
                    dersKredi = Convert.ToInt32(txtkredi.Text),
                    dersAkts = Convert.ToInt32(txtAkts.Text),
                    dersProfId = profesorId,
                    olusturmaTarihi = DateTime.Now,
                };
                db.Dersler.Add(yeniDers);
                timer1.Start();
                MessageBox.Show("Ders başarıyla oluşturuldu!");
            }
            else
            {
                int id = Convert.ToInt32(hiddenID.Text);
                var x = db.Dersler.Find(id);
                x.dersIsim = dersAdi;
                x.dersKod = txtkod.Text;
                x.dersKredi = Convert.ToInt32(txtkredi.Text);
                x.dersAkts = Convert.ToInt32(txtAkts.Text);
                x.dersProfId = profesorId;
                x.olusturmaTarihi = DateTime.Now;
                timer1.Start();
                MessageBox.Show("Ders başarıyla Güncellendi!");
            }
            db.SaveChanges();
            hiddenID.Text = "";
            DersGöster();
            Temizle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Kaydı Silmek İstediğinize Emin Misiniz ?", "Onay Bekleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (hiddenID.Text != null)
                {
                    int id = Convert.ToInt32(hiddenID.Text);
                    var x = db.Dersler.Find(id);//Hangi tablodan silme işlemini yapacaksın ve neye göre sileceksin
                    db.Dersler.Remove(x);
                    db.SaveChanges();
                    timer1.Start();
                    MessageBox.Show("Kayıt Silindi");
                    DersGöster();
                    Temizle();
                    hiddenID.Text = "";
                }
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            hiddenID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            dersad.Text = dataGridView1.CurrentRow.Cells["Ders_Adı"].Value.ToString();
            txtkod.Text = dataGridView1.CurrentRow.Cells["Ders_Kodu"].Value.ToString();
            txtAkts.Text = dataGridView1.CurrentRow.Cells["Ders_Akts"].Value.ToString();
            txtkredi.Text = dataGridView1.CurrentRow.Cells["Ders_Kredi"].Value.ToString();
            cmbProfesorler.Text = dataGridView1.CurrentRow.Cells["Prof_Ad"].Value.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            SendKeys.Send("{ESC}");
        }
    }
}
