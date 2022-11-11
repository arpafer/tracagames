import { Game } from './game';
export class Games {
   private games: Game[];

   constructor() {
      this.games = [];
   }

   set(games: Game[]) {
      this.games = games;
   }

   add(game: Game) {
     this.games.push(game);
   }
}
