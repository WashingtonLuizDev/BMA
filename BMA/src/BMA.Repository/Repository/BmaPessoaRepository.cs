using BMA.Domain.Models;
using BMA.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMA.Repository.Repository
{
    public class BmaPessoaRepository : IBmaPessoaRepository
    {
        private readonly BmaContext _context;

        public BmaPessoaRepository(BmaContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<List<PessoaModel>> GetAll()
        {
            IQueryable<PessoaModel> result = _context.Pessoas.AsNoTracking().OrderBy(h => h.Id);

            return await result.ToListAsync();
        }

        public async Task<PessoaModel> GetById(int id)
        {
            IQueryable<PessoaModel> result = _context.Pessoas.AsNoTracking().OrderBy(p => p.Id);

            return await result.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}