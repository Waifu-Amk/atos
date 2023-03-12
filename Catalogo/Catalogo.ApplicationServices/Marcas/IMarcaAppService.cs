
using Catalogo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.ApplicationServices.Marcas
{
    public interface IMarcaAppService
    {
        Task<List<Marca>> GetMarcasAsync();

        Task<Marca> GetMarcaAsync(int marcaId);
        
        Task EditMarcaAsync(Marca marca);

        Task DeleteMarcaAsync(int marcaId);

        Task<int> AddMarcaAsync(Marca marca);
    }
}
