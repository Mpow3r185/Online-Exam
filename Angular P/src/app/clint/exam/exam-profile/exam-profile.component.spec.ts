import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamProfileComponent } from './exam-profile.component';

describe('ExamProfileComponent', () => {
  let component: ExamProfileComponent;
  let fixture: ComponentFixture<ExamProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExamProfileComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExamProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
