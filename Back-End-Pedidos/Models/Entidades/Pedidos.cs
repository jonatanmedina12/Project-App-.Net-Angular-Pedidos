using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    public class Pedidos
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }
        public string DireccionEntrega { get; set; }
        public string Prioridad { get; set; }
        public List<Produtos> Productos { get; set; } = new List<Produtos>();
        public decimal ValorTotalPedido => Productos.Sum(p => p.ValorParcial);


    }
}
