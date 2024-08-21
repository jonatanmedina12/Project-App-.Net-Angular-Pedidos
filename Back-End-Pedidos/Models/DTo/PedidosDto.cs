using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTo
{
    public class PedidosDto
    {
        public ClienteDto Cliente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }
        public string DireccionEntrega { get; set; }
        public List<ProductoDto> Productos { get; set; } = new List<ProductoDto>();
    }
}
