import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminExamsComponent } from './admin-exams.component';

describe('AdminExamsComponent', () => {
  let component: AdminExamsComponent;
  let fixture: ComponentFixture<AdminExamsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminExamsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminExamsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
