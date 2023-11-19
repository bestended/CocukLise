using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreModel.Model
{
    public class Gorevler
    {
        [Key]
        public int gorevID { get; set; }

        public string gorevTanim { get; set; }
        public string gorevAdi { get; set; }
        public int puan { get; set; }

        public ICollection<Birimler> birimler { get; set; }
    }
}
