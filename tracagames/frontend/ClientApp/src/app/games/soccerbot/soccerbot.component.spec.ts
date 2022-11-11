import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SoccerbotComponent } from './soccerbot.component';

describe('SoccerbotComponent', () => {
  let component: SoccerbotComponent;
  let fixture: ComponentFixture<SoccerbotComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SoccerbotComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SoccerbotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
