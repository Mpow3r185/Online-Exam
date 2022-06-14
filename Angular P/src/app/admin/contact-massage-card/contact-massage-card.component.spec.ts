import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactMassageCardComponent } from './contact-massage-card.component';

describe('ContactMassageCardComponent', () => {
  let component: ContactMassageCardComponent;
  let fixture: ComponentFixture<ContactMassageCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContactMassageCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactMassageCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
