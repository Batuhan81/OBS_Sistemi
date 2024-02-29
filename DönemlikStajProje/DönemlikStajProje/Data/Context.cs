using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DönemlikStajProje.Data;

namespace DönemlikStajProje.Data
{
    public class Context : DbContext
    {

        

        public DbSet<Admin> Adminler { get; set; }
            public DbSet<AkademikTakvim> AkademikTakvimler { get; set; }
            public DbSet<Bolum> Bolumler { get; set; }
            public DbSet<Ders> Dersler { get; set; }
            public DbSet<Duyuru> Duyurular { get; set; }
            public DbSet<DuyuruAlici> DuyuruAlicilar { get; set; }
            public DbSet<Fakulte> Fakulteler { get; set; }
            public DbSet<FakulteBolum> FakulteBolumler { get; set; }
            public DbSet<Ogrenci> Ogrenciler { get; set; }
            public DbSet<OgrenciDers> OgrenciDersler { get; set; }
            public DbSet<OgrenciMesaj> ogrenciMesajlar { get; set; }
            public DbSet<Profesor> Profesorler { get; set; }
        
    }
}
