using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DönemlikStajProje.Data
{
    public class DuyuruAlici
    {
        public int duyuruAliciId { get; set; }
        public int duyuruId { get; set; }
        public Duyuru Duyuru { get; set; } 

        public int duyuruAlici_ogrenci { get; set; }
        public Ogrenci Ogrenci { get; set; } 

        public DateTime duyuruAliciOlusturmaTarihi { get; set; }
    }
}
