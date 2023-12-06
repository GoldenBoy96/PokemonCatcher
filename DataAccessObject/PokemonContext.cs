using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessObject;

public partial class PokemonContext : DbContext
{
    public PokemonContext()
    {
    }

    public PokemonContext(DbContextOptions<PokemonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pokemon> Pokemons { get; set; }

    //public virtual DbSet<PokemonLearnableMove> PokemonLearnableMoves { get; set; }

    //public virtual DbSet<PokemonLearnedMove> PokemonLearnedMoves { get; set; }

    public virtual DbSet<PokemonMove> PokemonMoves { get; set; }

    public virtual DbSet<PokemonSpecie> PokemonSpecies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Trace.WriteLine("================================"+GetConnectionString());
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }
    }

    private static string GetConnectionString()
    {
        IConfigurationRoot configuration = (new ConfigurationBuilder())
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        return configuration.GetConnectionString("DefaultConnection");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pokemon>(entity =>
        {
            entity.HasKey(e => e.PokemonId).HasName("PK__Pokemon__69C4E92391505AD7");
            entity.HasMany(e => e.PokemonMoves).WithMany(e => e.Pokemons);

            entity.ToTable("Pokemon");

            entity.Property(e => e.PokemonName).HasMaxLength(50);
        });

        modelBuilder.Entity<PokemonMove>(entity =>
        {
            entity.HasKey(e => e.MoveId).HasName("PK__PokemonM__A931A41C48C0241C");

            entity.HasMany(e => e.PokemonSpecies).WithMany(e => e.PokemonMoves);
            entity.HasMany(e => e.Pokemons).WithMany(e => e.PokemonMoves);

            entity.ToTable("PokemonMove");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.MoveName).HasMaxLength(50);
        });

        modelBuilder.Entity<PokemonSpecie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PokemonS__E9AA1A64354326FF");
            entity.HasMany(e => e.PokemonMoves).WithMany(e => e.PokemonSpecies);
            entity.ToTable("PokemonSpecie");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.SpecieName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
