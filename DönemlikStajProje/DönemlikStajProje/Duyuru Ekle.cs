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
    public partial class Duyuru_Ekle : Form
    {
        private string _gonderenAdi;

        public Duyuru_Ekle(string gonderenAdi)
        {
            InitializeComponent();
            _gonderenAdi = gonderenAdi;
        }
        Context db = new Context();
        Duyuru d = new Duyuru();
        bool durum;
        private void button1_Click(object sender, EventArgs e)
        {
            var admin = db.Adminler.FirstOrDefault(a => a.adminIsim == duyuruYapan.Text);
            var prof = db.Profesorler.FirstOrDefault(a => a.profesorIsim == duyuruYapan.Text);

            if (admin == null && prof == null)
            {
                MessageBox.Show("Sisteme Kayıtlı Kişi Bulunamadı Lütfen İsmi Kontrol Ediniz", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Metodu burada sonlandır
            }
            else
            {
                if (admin != null)
                {
                    if (checkBox1.Checked)
                    {
                        durum = true;
                    }
                    else
                    {
                        durum = false;
                    }
                    if (hiddenduyuruID.Text == null || hiddenduyuruID.Text == "")
                    {
                        d.duyuruMesaj = txtmetin.Text;
                        d.duyuruGonderici = admin.adminId;
                        d.olusturmaTarihi = DateTime.Now;
                        d.duyuruBaslik = başlık.Text;
                        d.duyuruAktifmi = durum;
                        d.duyuruBelgeYolu = label5.Text;
                        d.Yetki = true;
                        db.Duyurular.Add(d);
                        timer1.Start();
                        MessageBox.Show("Yeni Duyuru Oluşturuldu");
                    }
                    else
                    {
                        int id = Convert.ToInt32(hiddenduyuruID.Text);
                        var x = db.Duyurular.Find(id);
                        x.duyuruMesaj = txtmetin.Text;
                        x.duyuruGonderici = admin.adminId;
                        x.olusturmaTarihi = DateTime.Now;
                        x.duyuruBaslik = başlık.Text;
                        x.duyuruAktifmi = durum;
                        x.Yetki = true;
                        x.duyuruBelgeYolu = label5.Text;
                        x.duyuruMesaj = txtmetin.Text;
                        timer1.Start();
                        MessageBox.Show("Yeni Duyuru Başarıyla Güncellendi");
                    }
                }
                else
                {
                    if (checkBox1.Checked)
                    {
                        durum = true;
                    }
                    else
                    {
                        durum = false;
                    }
                    if (hiddenduyuruID.Text == null || hiddenduyuruID.Text == "")
                    {
                        d.duyuruMesaj = txtmetin.Text;
                        d.duyuruGonderici = prof.profesorId;
                        d.olusturmaTarihi = DateTime.Now;
                        d.duyuruBaslik = başlık.Text;
                        d.duyuruAktifmi = durum;
                        d.Yetki = false;
                        d.duyuruBelgeYolu = label5.Text;
                        db.Duyurular.Add(d);
                        timer1.Start();
                        MessageBox.Show("Yeni Duyuru Oluşturuldu");
                    }
                    else
                    {
                        int id = Convert.ToInt32(hiddenduyuruID.Text);
                        var x = db.Duyurular.Find(id);
                        x.duyuruMesaj = txtmetin.Text;
                        x.duyuruGonderici = prof.profesorId;
                        x.olusturmaTarihi = DateTime.Now;
                        x.duyuruBaslik = başlık.Text;
                        x.duyuruAktifmi = durum;
                        x.Yetki = false;
                        x.duyuruBelgeYolu = label5.Text;
                        x.duyuruMesaj = txtmetin.Text;
                        timer1.Start();
                        MessageBox.Show("Yeni Duyuru Başarıyla Güncellendi");
                    }
                }
                db.SaveChanges();
                duyuruListele();
                duyuruYapan.Text = "";
                hiddenduyuruID.Text = "";
                txtmetin.Text = "";
                başlık.Text = "";
                label5.Text = "";
            }
        }
        void duyuruListele()
        {
            var duyurular = db.Duyurular.ToList().Select(o => new
            {
                Duyuru_ID = o.duyuruId,
                Duyuru_Yapan = (o.Yetki) ? db.Adminler.FirstOrDefault(a => a.adminId == o.duyuruGonderici)?.adminIsim : db.Profesorler.FirstOrDefault(p => p.profesorId == o.duyuruGonderici)?.profesorIsim,
                Duyuru_Başlık = o.duyuruBaslik,
                Duyuru_İçerik = o.duyuruMesaj,
                Durumu = o.duyuruAktifmi ? "Aktif" : "Pasif",
                Dosya_Yolu = o.duyuruBelgeYolu,
                Yayım_Tarihi = o.olusturmaTarihi,
            }).ToList();

            gridDuyuru.DataSource = duyurular;
        }


        private void Duyuru_Ekle_Load(object sender, EventArgs e)
        {
            duyuruListele();
            checkBox1.Checked = true;
            duyuruYapan.Text = _gonderenAdi;
        }
        string a;
        private void gridDuyuru_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            başlık.Text = gridDuyuru.CurrentRow.Cells["Duyuru_Başlık"].Value.ToString();
            label5.Text = gridDuyuru.CurrentRow.Cells["Dosya_Yolu"].Value.ToString();
            a = gridDuyuru.CurrentRow.Cells["Durumu"].Value.ToString();
            if (a == "Aktif")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
            duyuruYapan.Text = gridDuyuru.CurrentRow.Cells["Duyuru_Yapan"].Value.ToString();
            txtmetin.Text = gridDuyuru.CurrentRow.Cells["Duyuru_İçerik"].Value.ToString();
            hiddenduyuruID.Text = gridDuyuru.CurrentRow.Cells["Duyuru_ID"].Value.ToString();
        }

        private void dosyaEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Tüm Dosyalar |*.*| Excel Dosyaları |*.xls;*xlsx| Word Dosyaları |*.docx;*.doc| Pdf Dosyaları |*.pdf";
            fileDialog.FilterIndex = 1;
            fileDialog.RestoreDirectory = true;
            fileDialog.CheckFileExists = true;
            fileDialog.Title = "Dosya Seçiniz";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(fileDialog.FileName); // Seçilen dosyanın bilgisini al

                // Dosya uzantısını kontrol ederek, doğru türde dosya seçildiğinden emin olun
                if (fileInfo.Extension == ".xls" || fileInfo.Extension == ".xlsx" || fileInfo.Extension == ".docx" || fileInfo.Extension == ".doc" || fileInfo.Extension == ".pdf")
                {
                    string dosyaYolu = fileInfo.FullName;
                    label5.Text = dosyaYolu;
                }
                else
                {
                    MessageBox.Show("Geçersiz dosya uzantısı! Lütfen .xls, .xlsx, .docx, .doc veya .pdf uzantılı bir dosya seçiniz.");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            SendKeys.Send("{ESC}");
        }
    }
}
