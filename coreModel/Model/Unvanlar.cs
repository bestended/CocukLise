using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreModel.Model
{
    public class Unvanlar
    {
        [Key]
        public int unvanID { get; set; }

        public string unvanAdi { get; set; }
    }
}
