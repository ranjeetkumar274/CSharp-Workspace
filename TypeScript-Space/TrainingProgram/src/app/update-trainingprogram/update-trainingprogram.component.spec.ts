import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateTrainingprogramComponent } from './update-trainingprogram.component';

describe('UpdateTrainingprogramComponent', () => {
  let component: UpdateTrainingprogramComponent;
  let fixture: ComponentFixture<UpdateTrainingprogramComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateTrainingprogramComponent]
    });
    fixture = TestBed.createComponent(UpdateTrainingprogramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
