import { TestBed } from '@angular/core/testing';

import { BrickService } from './brick.service';

describe('BrickService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BrickService = TestBed.get(BrickService);
    expect(service).toBeTruthy();
  });
});
