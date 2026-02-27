import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListTrainingprogramComponent } from './list-trainingprogram.component';

describe('ListTrainingprogramComponent', () => {
  let component: ListTrainingprogramComponent;
  let fixture: ComponentFixture<ListTrainingprogramComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListTrainingprogramComponent]
    });
    fixture = TestBed.createComponent(ListTrainingprogramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
