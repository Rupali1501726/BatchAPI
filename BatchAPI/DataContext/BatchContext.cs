using BatchAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BatchAPI.DataContext
{
    public class BatchContext : DbContext
    {
        public BatchContext(DbContextOptions options) : base(options) { }
        public DbSet<Batch> BatchDetails
        {
            get;
            set;
        }
        public DbSet<Files> files { get; set; }
    }
}
