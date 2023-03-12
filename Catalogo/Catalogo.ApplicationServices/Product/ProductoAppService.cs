using Catalogo.Core;
using Catalogo.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.ApplicationServices.Product
{
    public class ProductoAppService : IProductAppService
    {
        private readonly IRepository<int, Producto> _repository;
        public ProductoAppService(IRepository<int, Producto> repository)
        {
            _repository = repository;
        }
        public async Task<int> AddProductAsync(Producto producto)
        {
            await _repository.AddAsync(producto);
            return producto.Id;
        }

        public async Task DeleteProductoAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task EditProductoAsync(Producto producto)
        {
            await _repository.UpdateAsync(producto);
        }

        public async Task<List<Producto>> GetProductoAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<Producto> GetProductoAsync(int id)
        {
            return await _repository.GetAsync(id);
        }
    }
}
