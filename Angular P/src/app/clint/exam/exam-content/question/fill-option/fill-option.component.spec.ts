import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FillOptionComponent } from './fill-option.component';

describe('FillOptionComponent', () => {
  let component: FillOptionComponent;
  let fixture: ComponentFixture<FillOptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FillOptionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FillOptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
