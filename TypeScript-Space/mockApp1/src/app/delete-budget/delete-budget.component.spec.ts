import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteBudgetComponent } from './delete-budget.component';

describe('DeleteBudgetComponent', () => {
  let component: DeleteBudgetComponent;
  let fixture: ComponentFixture<DeleteBudgetComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteBudgetComponent]
    });
    fixture = TestBed.createComponent(DeleteBudgetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
