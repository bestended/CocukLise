using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreModel.Model
{
    public class Birimler
    {

        [Key]
        public int birimID { get; set; }
        [Required]
        public string birimAdi { get; set; }
        [Required]
        [Range(100, 200, ErrorMessage = "100 ile 200 arasında değer giriniz.")]
        public int birim { get; set; }

        public ICollection<Gorevler> gorev { get; set; }
    }
}
