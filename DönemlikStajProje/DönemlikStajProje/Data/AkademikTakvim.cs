using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DönemlikStajProje.Data
{
    public class AkademikTakvim
    {
        public int akademikTakvimId { get; set; }
        public DateTime akademikTakvimBaslangic { get; set; }
        public DateTime akademikTakvimBitis { get; set; }
        public string akademikTakvimAktivite { get; set; }
        public DateTime olusturmaTarihi { get; set; }
    }
}
