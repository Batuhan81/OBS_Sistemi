using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DönemlikStajProje.Data
{
    public class Fakulte
    {
        public int fakulteId { get; set; }
        public FakulteBolum FakulteBolum { get; set; } 

        public int fakulteProfId { get; set; }
        public Profesor Profesor { get; set; } 

        public string fakulteIsim { get; set; }
        public DateTime olusturmaTarihi { get; set; }
    }
}
