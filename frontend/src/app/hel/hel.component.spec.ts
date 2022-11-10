import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HelComponent } from './hel.component';

describe('HelComponent', () => {
  let component: HelComponent;
  let fixture: ComponentFixture<HelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HelComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
