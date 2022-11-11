import { WaitingUser } from './../../models/waitingUser/waiting-user';
import { environment } from './../../../environments/environment';
import { Subject, Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { User } from './../../models/user';
import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class WaitingRoomService {

   private users$: Subject<User[]> = new Subject<User[]>();
   private users: User[];
   private waitingUserAlready$: Subject<boolean> = new Subject<boolean>();
   private connectionHub: signalR.HubConnection;
   private waitingUser: WaitingUser;

   constructor(private httpClient: HttpClient) {
      this.waitingUser = new WaitingUser(new User("", "", false, ""), "", false);
      this.users$ = new Subject<User[]>();
      this.waitingUserAlready$ = new Subject<boolean>();
      this.users = [];
      this.connectionHub = new signalR.HubConnectionBuilder()
          .withUrl(environment.urlHub)
          .build();

      !environment.production && this.connectionHub.start().then(
            result => {
               console.log("SignalR se ha conectado con éxito");
            })
            .catch(function(e) {
               console.log("SignalR no se ha podido conectar: " + e.Message);
          });
      this.onNewUser();
      this.onRemoveUser();
   }

   private initWaitingUser() {
    this.waitingUser = new WaitingUser(new User("", "", false, ""), "", false);
   }

   hasWaitingUser() {
     return this.waitingUser.isIntroducedNick();
  }

   private onNewUser() {
    this.connectionHub.on("NewAvailableUser", (userName: string, email: string) => {
      console.log("usuario disponible: " + userName + " email: " + email);
      const user: User = new User(userName, email, true);
      this.users.push(user);
      this.users$.next(this.users);
   });
  }

   private onRemoveUser() {
    this.connectionHub.on("RemovedUser", (userName: string, email: string) => {
       console.log("usuario ha salido de la sala de espera: " + userName + " email: " + email);
       this.users = this.users.filter(u => u.email != email)
       this.users$.next(this.users);
    });
  }

  clear() {
    this.users = [];
    this.users$.next(this.users);
  }

  addUser(user: WaitingUser) {
      user.email = user.userName + "@email.com";
       this.httpClient.get<WaitingUser>(environment.urlApi + "WaitingRoom/GetWaitingUser?email=" + user.email + "&gameName=" + user.gameName).subscribe(
         (waitingUser: WaitingUser) => {
          if (waitingUser == null) {
            this.connectionHub.send("NewUser", user.userName, user.email)
            .then((done) => {
              this.waitingUser = new WaitingUser(user, user.getGameName(), true);
              this.insertUser(this.waitingUser);
              console.log("USUARIO ENVIADO CON EXITO");
              this.waitingUserAlready$.next(false);
            }).catch((e) => console.log("ERROR DE ENVIO: " + e.Message));
          } else {
             this.waitingUserAlready$.next(true);
              console.log("El usuario ya está en espera");
          }
         }, error => {
            console.log("Error: " + error.Message);
         }
      );
      // console.log("Email: " + user.email);
   }

   getUsers$(): Observable<User[]> {
       return this.users$.asObservable();
   }

   getWaitingUserAlready$(): Observable<boolean> {
       return this.waitingUserAlready$.asObservable();
   }

   getWaitingUsers(gameName: string) {
    /*  const user1: User = new User("Player1", "player1@email.com", true);
      const user2: User = new User("Player2", "player2@email.com", true);
      this.users.push(user1);
      this.users.push(user2); */
      this.httpClient.get<WaitingUser[]>(environment.urlApi + "WaitingRoom/GetWaitingUsers?gameName=" + gameName).subscribe(
         (waitingUsers: WaitingUser[]) => {
          this.users = [];
           waitingUsers.forEach(user => {
              this.users.push(new User(user.userName, user.email, user.logged, user.password));
           });
           this.users$.next(this.users);
         }
      )
   }

   removeUser(user: WaitingUser) {
     const params = new HttpParams();
     params.set("email", user.email);
     params.set("gameName", user.getGameName());
     console.log(user.email + "-" + user.getGameName());
     if (this.waitingUser.userName != null && this.waitingUser.userName != "") {
        const email = user.userName + "@email.com";
        // console.log(this.waitingUser);
        // const waitingUser = new WaitingUser(user, user.getGameName(), true);
        this.httpClient.delete<WaitingUser>(environment.urlApi + "WaitingRoom/deleteWaitingUser?info=" + btoa(email) + "|" + btoa(user.getGameName())).subscribe(
          (waitingUser: WaitingUser) => {
            this.connectionHub.send("RemoveUser", user.userName, user.email)
            .then((done) => {
               console.log("USUARIO ELIMINADO CON EXITO");
               this.initWaitingUser();
             })
            .catch((e) => console.log("ERROR DE ENVIO: " + e.Message));
          }
        );
     }
  }

  insertUser(user: WaitingUser) {
    var header = new HttpHeaders({
      'Content-Type':  'application/json'
    });
    const strUser = JSON.stringify(user);
     this.httpClient.post<WaitingUser>(environment.urlApi + "WaitingRoom/addWaitingUser", strUser, { headers: header }).subscribe(
      (waitingUser: WaitingUser) => {
       // this.users.push(waitingUser);
       // this.users$.next(this.users);
       }
     );

  /*   this.httpClient.post<string>(environment.urlApi + "WaitingRoom/addWaitingUser", "user", { headers: header }).subscribe(
      (id: string) => {
         console.log("id: " + id);
       // this.users.push(waitingUser);
       // this.users$.next(this.users);
       }
     ); */
  }
}

interface NewAvailableUser {
   userName: string;
   email: string;
   logged: boolean;
   password: string;
}
