using Microsoft.EntityFrameworkCore;
using BtkAkademi.Models;   // <- 'Akedemi'

namespace BtkAkademi.Data     // <- 'Akedemi'
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
    }
}
