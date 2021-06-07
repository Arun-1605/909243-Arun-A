import { TestBed } from '@angular/core/testing';

import { CompanyWatchServiceService } from './company-watch-service.service';

describe('CompanyWatchServiceService', () => {
  let service: CompanyWatchServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CompanyWatchServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
