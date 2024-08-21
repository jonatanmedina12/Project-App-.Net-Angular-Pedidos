import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { enviroment } from 'src/app/env/environment';

// Define tus interfaces para el DTO de pedidos y productos
interface Producto {
  codigo: string;
  nombre: string;
  valorUnitario: number;
  cantidad: number;
}

interface Cliente {
  id: number;
  nombre: string;
  direccion: string;
}

export interface PedidosDto {
  cliente: Cliente;
  fechaRegistro: string;
  estado: string;
  direccionEntrega: string;
  productos: Producto[];
}

@Injectable({
  providedIn: 'root'
})

export class PedidosServiciosService {

    private apiUrl = `${enviroment.apiUrl}pedidos`;  // Reemplaza con la URL de tu API
  
    constructor(private http: HttpClient) { }
  
    crearPedido(pedido: PedidosDto): Observable<any> {
      return this.http.post(this.apiUrl, pedido);
    
}
}
