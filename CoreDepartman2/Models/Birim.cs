using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDepartman2.Models
{
    public class Birim
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }

        public IList<Personel> Personels { get; set; }
    }
}
