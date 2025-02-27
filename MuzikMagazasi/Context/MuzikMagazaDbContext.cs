using Microsoft.EntityFrameworkCore;
using MuzikMagazasi.Context.Entities;

namespace MuzikMagazasi.Context
{
    public class MuzikMagazaDbContext : DbContext
    {
        public MuzikMagazaDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        public DbSet<Tarz> Tarzlar { get; set; }
        public DbSet<Yapimci> Yapimcilar { get; set; }
        //public DbSet<Publisher> Publishers { get; set; }
    }
}
