using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Core;

namespace Ventas.DataAccess
{
    public class VentasContext : IdentityDbContext
    {
        public virtual DbSet<Vendedor> Vendedores { get; set; }

        public virtual DbSet<VentaProducto> VentaProducto { get; set; }

        public VentasContext(DbContextOptions<VentasContext> options) : base(options) 
        {

        }
    }
}
