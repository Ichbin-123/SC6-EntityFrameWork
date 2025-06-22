using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC6_EntityFrameWork;
using SC6_EntityFrameWork.DAL.Models;

namespace SC6_EntityFrameWork.DAL;
public class TournamentContext : DbContext
{
    public TournamentContext()
    {
    }

    public TournamentContext(DbContextOptions<TournamentContext> options)
        : base(options)
    {
    }

    public DbSet<Giocatore> Giocatori => Set<Giocatore>();
    public DbSet<Squadra> Squadre => Set<Squadra>();
    public DbSet<Prenotazione> Prenotazioni => Set<Prenotazione>();
    public DbSet<Torneo> Tornei => Set<Torneo>();
    public DbSet<Location> Locations => Set<Location>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Prenotazione>()
            .HasKey(p => new { p.SquadraId, p.TorneoId });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=Tournament");
        }
    }
        
}
