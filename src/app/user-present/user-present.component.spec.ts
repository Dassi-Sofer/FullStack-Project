import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPresentComponent } from './user-present.component';

describe('UserPresentComponent', () => {
  let component: UserPresentComponent;
  let fixture: ComponentFixture<UserPresentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserPresentComponent]
    });
    fixture = TestBed.createComponent(UserPresentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
