import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PedidosAppComponent } from './pedidos-app/pedidos-app.component';
import { PedidosServiciosService } from './servicios/pedidos-servicios.service';




@NgModule({
  declarations: [
    PedidosAppComponent
  ],
  imports: [
    CommonModule,

  ],
  exports:[
    PedidosAppComponent
  ],
  providers: [PedidosServiciosService],


})
export class UsuarioModule { }
