using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class BaseDbContext : DbContext
    {
        #region Attributes

        public DbSet<Cargueiro> Cargueiros { get; set; }
        public DbSet<Mineral> Minerais { get; set; }
        public DbSet<TransporteCarga> Transportes { get; set; }

        #endregion

        #region Constructor

        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        #endregion
    }
}
