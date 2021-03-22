import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForexComponent } from './quotation.component';

describe('ForexComponent', () => {
  let component: ForexComponent;
  let fixture: ComponentFixture<ForexComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ForexComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ForexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
