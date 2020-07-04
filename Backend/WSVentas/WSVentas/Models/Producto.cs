using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Concepto = new HashSet<Concepto>();
        }

        public int Id { get; set; }
        public byte[] Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Costo { get; set; }

        public virtual ICollection<Concepto> Concepto { get; set; }
    }
}
