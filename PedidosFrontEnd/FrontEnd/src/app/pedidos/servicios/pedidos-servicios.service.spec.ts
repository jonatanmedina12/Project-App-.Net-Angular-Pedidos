import { TestBed } from '@angular/core/testing';

import { PedidosServiciosService } from './pedidos-servicios.service';

describe('PedidosServiciosService', () => {
  let service: PedidosServiciosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PedidosServiciosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
