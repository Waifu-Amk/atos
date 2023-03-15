using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Core
{
    public class VentaProducto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VendedorId { get; set; }
        [Required]
        public int ProductoId { get; set; }

    }
}
