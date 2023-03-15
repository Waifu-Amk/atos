using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Core;
using Ventas.DataAccess.Repositories;

namespace Ventas.ApplicationServices.VentasService
{
    public class VentasAppService : IVentasAppService
    {
        private readonly IRepository<int, VentaProducto> _repository;

        public VentasAppService(IRepository<int, VentaProducto> repository)
        {
            _repository = repository;
        }

        public async Task<int> AddVentaAsync(VentaProducto venta)
        {
            await _repository.AddAsync(venta);
            return venta.Id;
        }

        public async Task DeleteVentaAsync(int productId)
        {
            await _repository.DeleteAsync(productId);
        }

        public async Task EditVentaAsync(VentaProducto entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task<VentaProducto> GetVentaProductoAsync(int productId)
        {
            return await _repository.GetAsync(productId);
        }

        public async Task<List<VentaProducto>> GetVentaProductosAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }
    }
}
