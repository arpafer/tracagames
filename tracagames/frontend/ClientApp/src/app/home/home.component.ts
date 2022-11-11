import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Games } from './../models/Catalogue/games';
import { GamesCatalogueService } from './../services/games-catalogue.service';
import { Component } from '@angular/core';
import { Game } from '../models/Catalogue/game';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

   public games$: Observable<Game[]> = new Observable<Game[]>();
   public games: Game[] = [];

   constructor(private gamesCatalogueService: GamesCatalogueService, private router: Router) {

   }

   ngOnInit() {
      this.games$ = this.gamesCatalogueService.getGames$();
      this.games$.subscribe(
        (_games) => {
          this.games = [];
          _games.forEach(g => {
             this.games.push(g);
          })
        }
      );
      this.gamesCatalogueService.load();
   }

   onclickPlay(idGame: string): void {
      this.router.navigate([idGame]);
   }
}
