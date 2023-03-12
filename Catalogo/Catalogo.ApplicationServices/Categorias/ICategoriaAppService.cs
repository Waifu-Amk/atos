using Catalogo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.ApplicationServices.Categorias
{
    public interface ICategoriaAppService
    {
        Task<List<Categoria>> GetCategoriasAsync();

        Task<Categoria> GetCategoriaAsync(int categoriaId);

        Task EditCategoriaAsync(Categoria categoria);
        
        Task DeleteCategoriaAsync(int categiaId);

        Task<int> AddCategoriaAsync(Categoria categoria);
    }
}
