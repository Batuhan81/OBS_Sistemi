using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DönemlikStajProje.Data
{
    public class OgrenciDers
    {
        public int ogrenciDersId { get; set; }
        public int ogrenciId { get; set; }
        public int dersId { get; set; }
        public Ders Ders { get; set; }

        public int dersSinavSonuc1 { get; set; }
        public int dersSinavSonuc2 { get; set; }
        public int dersFinalSonuc { get; set; }
        public DateTime olusturmaTarihi { get; set; }
    }
}
