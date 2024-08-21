import { Component } from '@angular/core';
import { PedidosDto, PedidosServiciosService } from '../servicios/pedidos-servicios.service';

@Component({
  selector: 'app-pedidos-app',
  templateUrl: './pedidos-app.component.html',
  styleUrls: ['./pedidos-app.component.css']
})
export class PedidosAppComponent {
  pedido: PedidosDto = {
    cliente: {
      id: 0,
      nombre: '',
      direccion: ''
    },
    fechaRegistro: new Date().toISOString().slice(0, 10),  // Asume que la fecha está en formato YYYY-MM-DD
    estado: '',
    direccionEntrega: '',
    productos: [
      {
        codigo: '',
        nombre: '',
        valorUnitario: 0,
        cantidad: 0
      }
    ]
  };

  constructor(private pedidosService: PedidosServiciosService) { }

  agregarProducto() {
    this.pedido.productos.push({
      codigo: '',
      nombre: '',
      valorUnitario: 0,
      cantidad: 0
    });
  }

  eliminarProducto(index: number) {
    this.pedido.productos.splice(index, 1);
  }

  enviarPedido() {
    this.pedidosService.crearPedido(this.pedido).subscribe(
      response => {
        console.log('Pedido creado exitosamente', response);
      },
      error => {
        console.error('Error al crear el pedido', error);
      }
    );
  }
}
