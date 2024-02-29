using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DönemlikStajProje.Data
{
    public class OgrenciMesaj
    {
        public int ogrenciMesajId { get; set; }
        public int ogrenciMesajGonderici { get; set; }
        public int ogrenciMesajAlici { get; set; }
        public string ogrenciMesajMesaj { get; set; }
        public DateTime olusturmaTarihi { get; set; }
    }
}
