using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bieb.Models { 

public partial class BiebDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
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
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
}