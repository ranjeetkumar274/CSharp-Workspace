import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListGroundComponent } from './list-ground.component';

describe('ListGroundComponent', () => {
  let component: ListGroundComponent;
  let fixture: ComponentFixture<ListGroundComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListGroundComponent]
    });
    fixture = TestBed.createComponent(ListGroundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
