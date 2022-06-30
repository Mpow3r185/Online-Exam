import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamContentComponent } from './exam-content.component';

describe('ExamContentComponent', () => {
  let component: ExamContentComponent;
  let fixture: ComponentFixture<ExamContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExamContentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExamContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
