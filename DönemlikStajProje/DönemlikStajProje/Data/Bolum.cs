using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DönemlikStajProje.Data
{
    public class Bolum
    {
        public int bolumId { get; set; }
        public FakulteBolum FakulteBolum { get; set; }

        public int bolumProfId { get; set; }
        public string bolumIsim { get; set; }
        public DateTime olusturmaTarihi { get; set; }
    }
}
