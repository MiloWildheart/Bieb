using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.EntityFrameworkCore;

namespace Bieb.Models { 

public partial class BiebDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<BiebItem> BiebItems { get; set; }

    public BiebDbContext()
    {
    }

    public BiebDbContext(DbContextOptions<BiebDbContext> options)
        : base(options)
    {
    }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // this hardcoded string changes depending on whose computer the code runs
        => optionsBuilder.UseSqlServer("Server=DESKTOP-UN4S556;User ID=robin;Password=;Database=BiebDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<Author>().HasData(
    new Author { Id = 1, Name = "Ron", },
    new Author { Id = 2, Name = "Polina",  },
    new Author { Id = 3, Name = "Tom",  });

            //modelBuilder.Entity<BiebItem>().HasData(
                //new BiebItem { Id = 1, Titel = "barneys fucking stupid time with C#", MediaType = "Boek"});
// other entities here
    }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
}