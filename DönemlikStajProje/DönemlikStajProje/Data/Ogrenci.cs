using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DönemlikStajProje.Data
{
    public class Ogrenci
    {
        public int ogrenciId { get; set; }
        public OgrenciMesaj OgrenciMesaj { get; set; } 
        public OgrenciDers OgrenciDers { get; set; } 

        public int ogrenciDanisman { get; set; }
        public Profesor Profesor { get; set; } 

        public int ogrenciTc { get; set; }
        public int ogrenciNo { get; set; }
        public DateTime ogrenciDogumTarihi { get; set; }
        public bool ogrenciCinsiyet { get; set; }
        public string ogrenciIsim { get; set; } 
        public string ogrenciSoyad { get; set; } 
        public string ogrenciParola { get; set; } 
        public string ogrenciEposta { get; set; } 
        public int ogrenciBolum { get; set; }
        public string OgrenciFotoYolu { get; set; } // Öğrenci fotoğrafının dosya yolunu saklar
        public Bolum Bolum { get; set; } 

        public DateTime ogrenciOlusturmaTarihi { get; set; }
    }
}
