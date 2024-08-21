using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTo;
using Models.Entidades;

namespace Back_End_Pedidos.Controllers
{

    public class PedidosController : BaseController
    {
        private readonly ApplicationDbContext _db;
        public PedidosController(ApplicationDbContext db)
        {
            _db = db;
        }
        private string DeterminarPrioridad(decimal valorTotal)
        {
            if (valorTotal <= 500) return "Baja";
            if (valorTotal <= 1000) return "Media";
            return "Alta";
        }

        [HttpPost]
        public async Task<ActionResult> CrearPedido([FromBody] PedidosDto pedidoDto)
        {
            if (pedidoDto == null)
                return BadRequest("Los datos del pedido son inválidos.");

            // Calcular el valor total del pedido
            decimal valorTotal = pedidoDto.Productos.Sum(p => p.ValorUnitario * p.Cantidad);

            // Determinar la prioridad
            string prioridad = DeterminarPrioridad(valorTotal);

            // Crear el modelo de Pedido
            var pedido = new Pedidos
            {
                Cliente = new Cliente
                {
                    Id = pedidoDto.Cliente.Id,
                    Nombre = pedidoDto.Cliente.Nombre,
                    Direccion = pedidoDto.Cliente.Direccion
                },
                FechaRegistro = pedidoDto.FechaRegistro,
                Estado = pedidoDto.Estado,
                DireccionEntrega = pedidoDto.DireccionEntrega,
                Prioridad = prioridad,
                Productos = pedidoDto.Productos.Select(p => new Produtos
                {
                    Codigo = p.Codigo,
                    Nombre = p.Nombre,
                    ValorUnitario = p.ValorUnitario,
                    Cantidad = p.Cantidad
                }).ToList()
            };

            // Agregar el pedido al contexto
            _db.Pedidos.Add(pedido);

            // Guardar los cambios en la base de datos
            await _db.SaveChangesAsync();

            return Ok(pedido);
        }

    }
}
