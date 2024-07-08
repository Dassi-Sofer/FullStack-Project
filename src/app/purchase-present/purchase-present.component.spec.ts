import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchasePresentComponent } from './purchase-present.component';

describe('PurchasePresentComponent', () => {
  let component: PurchasePresentComponent;
  let fixture: ComponentFixture<PurchasePresentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PurchasePresentComponent]
    });
    fixture = TestBed.createComponent(PurchasePresentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
