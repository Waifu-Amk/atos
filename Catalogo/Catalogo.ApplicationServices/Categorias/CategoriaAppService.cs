using Catalogo.Core;
using Catalogo.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.ApplicationServices.Categorias
{
    public class CategoriaAppService : ICategoriaAppService
    {
        private readonly IRepository<int, Categoria> _repository;
        public CategoriaAppService(IRepository<int, Categoria> repository)
        {
            _repository = repository;
        }

        public async Task<int> AddCategoriaAsync(Categoria categoria)
        {
            await _repository.AddAsync(categoria);
            return categoria.Id;
        }

        public async Task DeleteCategoriaAsync(int categiaId)
        {
            await _repository.DeleteAsync(categiaId);
        }

        public async Task EditCategoriaAsync(Categoria categoria)
        {
            await _repository.UpdateAsync(categoria);
        }

        public async Task<Categoria> GetCategoriaAsync(int categoriaId)
        {
            return await _repository.GetAsync(categoriaId);
        }

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }
    }
}
