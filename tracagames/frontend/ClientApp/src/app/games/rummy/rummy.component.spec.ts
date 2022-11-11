import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RummyComponent } from './rummy.component';

describe('RummyComponent', () => {
  let component: RummyComponent;
  let fixture: ComponentFixture<RummyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RummyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RummyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
