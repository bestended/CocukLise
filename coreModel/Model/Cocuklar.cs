using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreModel.Model
{
    public class Cocuklar
    {
        [Key]
        public int cocukID { get; set; }
        public string adSoyad { get; set; }
        public string cinsiyet { get; set; }
        public DateTime DogumTarih { get; set; }

        [ForeignKey("calisanID")]
        public int calisanID { get; set; }

        public Personeller calisan { get; set; }
    }
}
