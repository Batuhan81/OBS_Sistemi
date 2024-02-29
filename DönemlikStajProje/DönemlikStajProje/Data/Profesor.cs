using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DönemlikStajProje.Data
{
    public class Profesor
    {
        public int profesorId { get; set; }
        public string profesorIsim { get; set; }
        public string profesorSoyad { get; set; }
        public string profesorParola { get; set; }
        public string profesorUnvan { get; set; }
        public string profesorEposta { get; set; }
        public string profesorOfisAdresi { get; set; }
        public string profesorGorusmeSaatleri { get; set; }
        public string profesorFotoYolu { get; set; } // Öğrenci fotoğrafının dosya yolunu saklar
        public DateTime olusturmaTarihi { get; set; }
    }
}
