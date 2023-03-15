using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Core;

namespace Ventas.ApplicationServices.VentasService
{
    public interface IVentasAppService
    {
        Task<List<VentaProducto>> GetVentaProductosAsync();

        Task<VentaProducto> GetVentaProductoAsync(int productId);

        Task EditVentaAsync(VentaProducto entity);

        Task<int> AddVentaAsync(VentaProducto venta);

        Task DeleteVentaAsync(int productId);
    }
}
