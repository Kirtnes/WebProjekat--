using Microsoft.EntityFrameworkCore;

namespace bek.Models
{
    public class SalaContext : DbContext
    {
         public DbSet<Sala> Sale {get;set; }
         public DbSet<Sediste> Sedista {get; set; }
         public DbSet<Osoba> Osobe {get; set; }

         public SalaContext(DbContextOptions options) : base(options)
         {


         }

    }
}