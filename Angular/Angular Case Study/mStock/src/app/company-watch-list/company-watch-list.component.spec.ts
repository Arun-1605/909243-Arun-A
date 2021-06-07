import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyWatchListComponent } from './company-watch-list.component';

describe('CompanyWatchListComponent', () => {
  let component: CompanyWatchListComponent;
  let fixture: ComponentFixture<CompanyWatchListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompanyWatchListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CompanyWatchListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
