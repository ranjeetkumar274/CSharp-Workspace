import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteGroundComponent } from './delete-ground.component';

describe('DeleteGroundComponent', () => {
  let component: DeleteGroundComponent;
  let fixture: ComponentFixture<DeleteGroundComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteGroundComponent]
    });
    fixture = TestBed.createComponent(DeleteGroundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
