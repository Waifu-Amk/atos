using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Models.Venta
{
    public class VentaProducto
    {
        public int Id {
            get; set;
        }
        public int VendedorId { get; set; }

        public int ProductoId {
            get; set;
        }
    }
}
