using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreModel.Model
{
    public class Projeler
    {

        [Key]
        public int projeID { get; set; }
        public string projeAdi { get; set; }

        public DateTime projeBaslangicTarih { get; set; }
        public DateTime projeBitisTarih { get; set; }
        [ForeignKey("gorevID")]
        public int gorevID { get; set; }
        public Gorevler gorev { get; set; }
    }
}
