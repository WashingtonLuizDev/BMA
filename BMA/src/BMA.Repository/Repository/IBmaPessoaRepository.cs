using BMA.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BMA.Repository.Repository
{
    public interface IBmaPessoaRepository : IBmaBaseRepository
    {

        Task<List<PessoaModel>> GetAll();

        Task<PessoaModel> GetById(int id);
    }
}