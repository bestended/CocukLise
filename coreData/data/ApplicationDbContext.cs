using coreModel.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreData.data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Gorevler> gorevs { get; set; }
        public DbSet<Personeller> calisans { get; set; }
        public DbSet<Cocuklar> cocuks { get; set; }
        public DbSet<Projeler> projes { get; set; }
        public DbSet<Unvanlar> unvans { get; set; }
        public DbSet<Birimler> birims { get; set; }

    }




}

