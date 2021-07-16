using BMA.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BMA.Service.Interfaces
{
    public interface IBmaPessoaService
    {
        Task<List<PessoaModel>> GetAllPersonsAsync();

        Task<PessoaModel> GetPersonByIdAsync(int id = 0);

        Task<bool> AddPersonAsync(PessoaModel pessoa);

        Task<bool> UpdatePersonAsync(PessoaModel pessoa);

        Task<bool> RemovePersonAsync(PessoaModel pessoa);
    }
}