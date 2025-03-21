import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SnackBarMessageComponent } from './snack-bar-message.component';

describe('SnackBarMessageComponent', () => {
  let component: SnackBarMessageComponent;
  let fixture: ComponentFixture<SnackBarMessageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SnackBarMessageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SnackBarMessageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
