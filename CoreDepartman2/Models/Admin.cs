using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDepartman2.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        // Kullanıcı adı en fazla 15 karakter içerebilir
        [Column(TypeName = "Varchar(15)")]
        public string Kullanici { get; set; }

        // Şifre en fazla 8 karakter içerebilir
        [Column(TypeName = "Varchar(8)")]
        public string Sifre { get; set; }
    }
}
