using BMA.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BMA.Repository.Context
{
    public class BmaContext : DbContext
    {
        public BmaContext(DbContextOptions<BmaContext> options) : base(options)
        {
        }

        public DbSet<PessoaModel> Pessoas { get; set; }
    }
}