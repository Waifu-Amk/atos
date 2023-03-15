using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Core;

namespace Ventas.ApplicationServices.VendedorService
{
    public interface IVendedorAppService
    {
        Task<List<Vendedor>> GetVendedoresAsync();

        Task<Vendedor> GetVendedorAsync(int id);

        Task EditVendedorAsync(Vendedor vendedor);

        Task DeleteVendedorAsync(int id);

        Task<int> AddVendedorAsync(Vendedor vendedor);
    }
}
