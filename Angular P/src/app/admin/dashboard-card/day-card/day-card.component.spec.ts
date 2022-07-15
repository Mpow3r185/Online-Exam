import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DayCardComponent } from './day-card.component';

describe('DayCardComponent', () => {
  let component: DayCardComponent;
  let fixture: ComponentFixture<DayCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DayCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DayCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
