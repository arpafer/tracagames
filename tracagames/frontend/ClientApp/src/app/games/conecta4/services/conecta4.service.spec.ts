import { TestBed } from '@angular/core/testing';

import { Conecta4Service } from './conecta4.service';

describe('Conecta4Service', () => {
  let service: Conecta4Service;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Conecta4Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
