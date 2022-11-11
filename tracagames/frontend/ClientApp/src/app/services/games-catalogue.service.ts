import { environment } from './../../environments/environment.prod';
import { HttpClient } from '@angular/common/http';
import { Game } from './../models/Catalogue/game';
import { IGamesCatalogue } from './i-games-catalogue';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GamesCatalogueService implements IGamesCatalogue {

  private games: Game[];
  private games$: Subject<Game[]>;

  constructor(private httpClient: HttpClient) {
     this.games = [];
     this.games$ = new Subject<Game[]>();
  }

  getGames$(): Observable<Game[]> {
     return this.games$.asObservable();
  }

  add(game: Game) {
     this.games.push(game);
     this.games$.next(this.games);
  }

  load() {
    this.httpClient.get<Game[]>(environment.urlApi).subscribe(
      (games: Game[]) => {
         this.games = [];
         games.forEach(g => {
           this.games.push(new Game(g.id, g.name, g.description, g.imageBase64));
         });
         this.games$.next(this.games);
      }
    );
  }
}
