using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreModel.Model
{
    public class Personeller
    {
        [Key]
        public int calisanID { get; set; }
        [Required]
        public string adSoyad { get; set; }

        public string calisanCinsiyet { get; set; }

        public DateTime iseBaslamaTarih { get; set; }
        public bool calisanVardiya { get; set; }

        public decimal calisanMaas { get; set; }
        public decimal calisanPrim { get; set; }
        [ForeignKey("gorevID")]
        public int gorevID { get; set; }
        [ForeignKey("unvanID")]
        public int unvanID { get; set; }

        public Gorevler gorev { get; set; }
        public Unvanlar unvan { get; set; }

    }
}
