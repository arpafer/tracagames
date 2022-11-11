import { TestBed } from '@angular/core/testing';

import { GamesCatalogueService } from './games-catalogue.service';

describe('GamesCatalogueService', () => {
  let service: GamesCatalogueService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GamesCatalogueService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
