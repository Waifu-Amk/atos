using Catalogo.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.DataAccess
{
    public class CatalogoContext :IdentityDbContext
    {
        public virtual DbSet<Categoria> Categorias { get; set; }

        public virtual DbSet<Marca> Marcas { get; set; }

        public virtual DbSet<Producto> Productos { get; set; }

        public CatalogoContext(DbContextOptions<CatalogoContext> options ) : base(options)
        {

        }
    }
}
