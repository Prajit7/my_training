import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpManagerComponent } from './emp-manager.component';

describe('EmpManagerComponent', () => {
  let component: EmpManagerComponent;
  let fixture: ComponentFixture<EmpManagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmpManagerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmpManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
