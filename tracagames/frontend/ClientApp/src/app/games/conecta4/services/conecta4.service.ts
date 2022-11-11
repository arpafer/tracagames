import { environment } from './../../../../environments/environment';
import { BehaviorSubject } from 'rxjs';
import { Conecta4Module } from './../conecta4.module';
import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: Conecta4Module
})
export class Conecta4Service {

  public connection;
  private sended: boolean;
  // public messageSubject$: BehaviorSubject<Message>;

  constructor() {

   // this.messageSubject$ = new BehaviorSubject<Message>(new Message("", ""));
    this.sended = true;
    this.connection = new signalR.HubConnectionBuilder()
       .withUrl("https://localhost:7201/chat")
       .build();

    !environment.production && this.connection.start().then(
      result => {
         console.log("SignalR se ha conectado con éxito");
      })
      .catch(function(e) {
         console.log("SignalR no se ha podido conectar: " + e.Message);
    });

 /*   this.connection.on("messageReceived", (username: string, message: string) => {
      console.log("mensaje recibido: " + username + ", " + message);
      this.messageSubject$.next(new Message(username, message));
   }); */
      this.connect();
  }

  public connect() {
    this.connection.on("messageReceived", (username: string, message: string) => {
      console.log("mensaje recibido: " + username + ", " + message);
      // this.messageSubject$.next(new Message(username, message));
   });
  }
}
