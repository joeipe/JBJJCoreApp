import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SparringDetailsComponent } from './sparring-details.component';

describe('SparringDetailsComponent', () => {
  let component: SparringDetailsComponent;
  let fixture: ComponentFixture<SparringDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SparringDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SparringDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
