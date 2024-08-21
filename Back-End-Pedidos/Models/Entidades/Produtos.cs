using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    public class Produtos
    {
        public int Id { get; set; } // Este será la clave primaria

        public string Codigo { get; set; }
            public string Nombre { get; set; }
            public decimal ValorUnitario { get; set; }
            public int Cantidad { get; set; }
            public decimal ValorParcial => ValorUnitario * Cantidad;
        


    }
}
