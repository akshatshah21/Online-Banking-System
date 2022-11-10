import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeneManageComponent } from './bene-manage.component';

describe('BeneManageComponent', () => {
  let component: BeneManageComponent;
  let fixture: ComponentFixture<BeneManageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BeneManageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BeneManageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
