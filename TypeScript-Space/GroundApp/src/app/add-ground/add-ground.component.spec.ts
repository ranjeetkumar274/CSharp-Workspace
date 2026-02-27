import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddGroundComponent } from './add-ground.component';

describe('AddGroundComponent', () => {
  let component: AddGroundComponent;
  let fixture: ComponentFixture<AddGroundComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddGroundComponent]
    });
    fixture = TestBed.createComponent(AddGroundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
