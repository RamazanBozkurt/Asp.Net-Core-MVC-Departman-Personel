using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDepartman2.Models
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql();
        }
        public DbSet<Birim> Birims { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
