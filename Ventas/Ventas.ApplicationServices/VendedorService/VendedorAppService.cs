using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Core;
using Ventas.DataAccess.Repositories;

namespace Ventas.ApplicationServices.VendedorService
{
    public class VendedorAppService : IVendedorAppService
    {
        private readonly IRepository<int, Vendedor> _repository;
        public VendedorAppService(IRepository<int, Vendedor> repository)
        {
            _repository = repository;
        }

        public async Task<int> AddVendedorAsync(Vendedor vendedor)
        {
            await _repository.AddAsync(vendedor);
            return vendedor.Id;
        }

        public async Task DeleteVendedorAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task EditVendedorAsync(Vendedor vendedor)
        {
            await _repository.UpdateAsync(vendedor);
        }

        public async Task<Vendedor> GetVendedorAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<List<Vendedor>> GetVendedoresAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }
    }
}
