using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DönemlikStajProje.Data
{
    public class Admin
    {
        public int adminId { get; set; }
        public string adminIsim { get; set; }
        public string adminSoyad { get; set; }
        public string adminParola { get; set; }
        public string adminEposta { get; set; }
        public string adminFotoYolu { get; set; }
        public DateTime olusturmaTarihi { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }
    }
}
