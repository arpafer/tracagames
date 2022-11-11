import { User } from './../user';

export class WaitingUser extends User {
   public introducedNick: boolean;
   public gameName: string;
   public fecha: Date;

   constructor(user: User, gameName: string, introducedNick: boolean = false) {
      super(user.userName, user.userName + "@email.com", user.logged);
      this.introducedNick = introducedNick;
      this.gameName = gameName;
      this.fecha = new Date();
   }

   isIntroducedNick(): boolean {
      return this.introducedNick;
   }

   setNick(nick: string) {
      this.userName = nick;
      this.introducedNick = true;
      this.fecha = new Date();
   }

   public getGameName(): string {
       return this.gameName;
   }
}
