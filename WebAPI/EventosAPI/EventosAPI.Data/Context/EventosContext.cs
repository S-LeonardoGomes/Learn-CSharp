using EventosAPI.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace EventosAPI.Data.Context
{
    public class EventosContext : DbContext
    {
        public EventosContext(DbContextOptions<EventosContext> options) : base(options)
        {
        }

        public EventosContext() { }

        public DbSet<Convidado> Convidado { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Lote> Lote { get; set; }
        public DbSet<Palestrante> Palestrante { get; set; }
        public DbSet<PalestranteEvento> PalestranteEvento { get; set; }
        public DbSet<RedeSocial> RedeSocial { get; set; }
    }
}
