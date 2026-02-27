import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTrainingprogramComponent } from './add-trainingprogram.component';

describe('AddTrainingprogramComponent', () => {
  let component: AddTrainingprogramComponent;
  let fixture: ComponentFixture<AddTrainingprogramComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddTrainingprogramComponent]
    });
    fixture = TestBed.createComponent(AddTrainingprogramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
