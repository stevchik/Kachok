using Microsoft.EntityFrameworkCore;

namespace Kachok.Data.Infrastructure.Logging
{
    public class KachokLoggingContext : DbContext
    {
        public DbSet<RequestLog> Logs { get; set; }

        public KachokLoggingContext(DbContextOptions<KachokLoggingContext> options)
             : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
