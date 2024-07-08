import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SecondDonorComponent } from './second-donor.component';

describe('SecondDonorComponent', () => {
  let component: SecondDonorComponent;
  let fixture: ComponentFixture<SecondDonorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SecondDonorComponent]
    });
    fixture = TestBed.createComponent(SecondDonorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
