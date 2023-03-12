using Catalogo.Core;
using Catalogo.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.ApplicationServices.Marcas

{
    public class MarcaAppService : IMarcaAppService
    {
        private readonly IRepository<int, Marca> _repository;
        public MarcaAppService(IRepository<int, Marca> repository)
        {
            _repository = repository;
        }
        public async Task<int> AddMarcaAsync(Marca marca)
        {
            await _repository.AddAsync(marca);
            return marca.Id;
        }

        public async Task DeleteMarcaAsync(int marcaId)
        {
            await _repository.DeleteAsync(marcaId);
        }

        public async Task EditMarcaAsync(Marca marca)
        {
            await _repository.UpdateAsync(marca);
        }

        public async Task<Marca> GetMarcaAsync(int marcaId)
        {
            return await _repository.GetAsync(marcaId);
        }

        public async Task<List<Marca>> GetMarcasAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }
    }
}
