
using Catalogo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.ApplicationServices.Product
{
    public interface IProductAppService
    {
        Task<List<Producto>> GetProductoAsync();

        Task<Producto> GetProductoAsync(int id);

        Task EditProductoAsync(Producto producto);

        Task DeleteProductoAsync(int id);

        Task<int> AddProductAsync(Producto producto);
    }
}
