import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeneNewComponent } from './bene-new.component';

describe('BeneNewComponent', () => {
  let component: BeneNewComponent;
  let fixture: ComponentFixture<BeneNewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BeneNewComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(BeneNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
