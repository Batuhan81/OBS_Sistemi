using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DönemlikStajProje.Data
{
    public class Duyuru
    {
        public int duyuruId { get; set; }
        public int duyuruGonderici { get; set; }

        public string duyuruBaslik {  get; set; }
        public bool duyuruAktifmi {  get; set; }

        public bool Yetki {  get; set; }

        public string duyuruBelgeYolu { get; set; }

        public Profesor Profesor { get; set; }

        public string duyuruMesaj { get; set; }
        public DateTime olusturmaTarihi { get; set; }
    }
}
