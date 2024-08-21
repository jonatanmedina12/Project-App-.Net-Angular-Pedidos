import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PedidosAppComponent } from './pedidos-app.component';

describe('PedidosAppComponent', () => {
  let component: PedidosAppComponent;
  let fixture: ComponentFixture<PedidosAppComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PedidosAppComponent]
    });
    fixture = TestBed.createComponent(PedidosAppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
