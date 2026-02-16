import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TravelBucketlistComponent } from './travel-bucketlist.component';

describe('TravelBucketlistComponent', () => {
  let component: TravelBucketlistComponent;
  let fixture: ComponentFixture<TravelBucketlistComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TravelBucketlistComponent]
    });
    fixture = TestBed.createComponent(TravelBucketlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
