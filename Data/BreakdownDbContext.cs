using Microsoft.EntityFrameworkCore;
using RNRAPP.Models;
using System;

namespace RNRAPP.Data
{
    public class BreakdownDbContext : DbContext
    {
        public BreakdownDbContext(DbContextOptions<BreakdownDbContext> options) : base(options)
        {

        }
        public DbSet<Breakdown> Breakdowns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=(localdb)\\localhost; Initial Catalog=RightNowResponse; TrustServerCertificate= True");
        }
    }
}
