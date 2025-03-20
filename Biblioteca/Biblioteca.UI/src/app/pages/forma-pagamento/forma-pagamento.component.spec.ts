import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormaPagamentoComponent } from './forma-pagamento.component';

describe('FormaPagamentoComponent', () => {
  let component: FormaPagamentoComponent;
  let fixture: ComponentFixture<FormaPagamentoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormaPagamentoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FormaPagamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
