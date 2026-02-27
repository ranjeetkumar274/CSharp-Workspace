import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListTrainingprogramsComponent } from './list-trainingprograms.component';

describe('ListTrainingprogramsComponent', () => {
  let component: ListTrainingprogramsComponent;
  let fixture: ComponentFixture<ListTrainingprogramsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListTrainingprogramsComponent]
    });
    fixture = TestBed.createComponent(ListTrainingprogramsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
