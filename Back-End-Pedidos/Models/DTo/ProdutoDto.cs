using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTo
{
    public class ProductoDto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Cantidad { get; set; }
    }
}
