import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestimonialViewComponent } from './testimonial-view.component';

describe('TestimonialViewComponent', () => {
  let component: TestimonialViewComponent;
  let fixture: ComponentFixture<TestimonialViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestimonialViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TestimonialViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
