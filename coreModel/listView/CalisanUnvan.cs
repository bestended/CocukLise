using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreModel.listView
{
    public class CalisanUnvan
    {

        public int calisanID { get; set; }
        [Required]
        public string adSoyad { get; set; }

        public string calisanCinsiyet { get; set; }

        public DateTime iseBaslamaTarih { get; set; }
        public bool calisanVardiya { get; set; }

        public decimal calisanMaas { get; set; }
        public decimal calisanPrim { get; set; }


        public int unvanID { get; set; }

        public string unvanAdi { get; set; }
    }
}
