using BMA.Domain.Models;
using BMA.Repository.Repository;
using BMA.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BMA.Service
{
    public class BmaPessoaServices : IBmaPessoaService
    {
        private IBmaPessoaRepository _repository;

        public BmaPessoaServices(IBmaPessoaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PessoaModel>> GetAllPersonsAsync()
        {
            return await _repository.GetAll().ConfigureAwait(false);
        }

        public async Task<PessoaModel> GetPersonByIdAsync(int id = 0)
        {
            return id != 0 ? await _repository.GetById(id).ConfigureAwait(false) : default;
        }

        public async Task<bool> AddPersonAsync(PessoaModel pessoa)
        {
            _repository.Add(pessoa);

            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> UpdatePersonAsync(PessoaModel pessoa)
        {
            _repository.Update(pessoa);

            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> RemovePersonAsync(PessoaModel pessoa)
        {
            _repository.Delete(pessoa);

            return await _repository.SaveChangesAsync();
        }
    }
}