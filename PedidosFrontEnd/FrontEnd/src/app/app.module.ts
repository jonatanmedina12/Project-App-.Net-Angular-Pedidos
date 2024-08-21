import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'; // Importa HttpClientModule

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PedidosAppComponent } from './pedidos/pedidos-app/pedidos-app.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    PedidosAppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,  // Añade HttpClientModule a los imports

    FormsModule  // Añade FormsModule a los imports
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
