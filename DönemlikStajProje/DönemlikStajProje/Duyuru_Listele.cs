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
    public partial class Duyuru_Listele : Form
    {
        public Duyuru_Listele()
        {
            InitializeComponent();
        }
        Context db=new Context();
        private void DuyurulariListele()
        {
            try
            {
                var duyurular = from duyuru in db.Duyurular
                                join admin in db.Adminler on duyuru.duyuruGonderici equals admin.adminId into adminDuyurular
                                from adminDuyuru in adminDuyurular.DefaultIfEmpty()
                                join hoca in db.Profesorler on duyuru.duyuruGonderici equals hoca.profesorId into hocaDuyurular
                                from hocaDuyuru in hocaDuyurular.DefaultIfEmpty()
                                where duyuru.duyuruAktifmi == true
                                select new
                                {
                                    Baslik = duyuru.duyuruBaslik,
                                    Duyuran = duyuru.Yetki ? adminDuyuru.adminIsim + " " + adminDuyuru.adminSoyad :
                                              hocaDuyuru.profesorIsim + " " + hocaDuyuru.profesorSoyad,
                                    Icerik = duyuru.duyuruMesaj,
                                    DosyaYolu = duyuru.duyuruBelgeYolu
                                };

                int groupBoxTop = 5; // GroupBox'ların başlangıç yüksekliği
                int groupBoxHeight = 200; // GroupBox yüksekliği
                int groupBoxWidth = 350; // GroupBox genişliği
                int groupBoxLeft = 10; // GroupBox'ların başlangıç sol kenarı
                int a=0;
                foreach (var duyuru in duyurular)
                {
                    if(a%4==0 && a!=0)
                    {
                        groupBoxTop = 5;
                        groupBoxLeft += groupBoxLeft + groupBoxWidth + 10;
                    }
                    GroupBox groupBox = new GroupBox();
                    groupBox.Text = duyuru.Baslik;
                    groupBox.Size = new Size(groupBoxWidth, groupBoxHeight);
                    groupBox.Location = new Point(groupBoxLeft, groupBoxTop);
                    groupBox.Font = new Font(groupBox.Font, FontStyle.Bold);

                    Label lblDuyuran = new Label();
                    lblDuyuran.AutoSize = true;
                    lblDuyuran.Text = "Duyuran: " + duyuru.Duyuran;
                    lblDuyuran.Location = new Point(10, 30);
                    lblDuyuran.Font = new Font(lblDuyuran.Font, FontStyle.Bold);
                    groupBox.Controls.Add(lblDuyuran);

                    TextBox txtIcerik = new TextBox();
                    txtIcerik.Multiline = true;
                    txtIcerik.ReadOnly = true;
                    txtIcerik.ScrollBars = ScrollBars.Vertical;
                    txtIcerik.Text = duyuru.Icerik;
                    txtIcerik.Size = new Size(300, 100);
                    txtIcerik.Location = new Point(10, 60);
                    groupBox.Controls.Add(txtIcerik);

                    if (!string.IsNullOrEmpty(duyuru.DosyaYolu))
                    {
                        LinkLabel lnkDosya = new LinkLabel();
                        lnkDosya.Text = "Dosyayı İndir";
                         lnkDosya.Location = new Point(10, 170);
                        lnkDosya.LinkClicked += (sender, e) =>
                        {
                            System.Diagnostics.Process.Start(duyuru.DosyaYolu);
                        };
                        groupBox.Controls.Add(lnkDosya);
                    }
                    a++;
                    groupBoxTop += groupBoxHeight + 5;
                    this.Controls.Add(groupBox);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Duyurular listelenirken bir hata oluştu: " + ex.Message);
            }
        }


        private void Duyuru_Listele_Load(object sender, EventArgs e)
        {
            DuyurulariListele();
        }
    }
}
