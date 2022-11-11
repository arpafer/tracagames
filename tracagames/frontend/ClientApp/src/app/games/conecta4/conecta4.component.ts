import { WaitingUser } from './../../models/waitingUser/waiting-user';
import { Observable } from 'rxjs';
import { WaitingRoomService } from './../../services/waiting-room/waiting-room.service';
import { User } from './../../models/user';
import { Component, HostListener, OnInit } from '@angular/core';

@Component({
  selector: 'app-conecta4',
  templateUrl: './conecta4.component.html',
  styleUrls: ['./conecta4.component.css']
})
export class Conecta4Component implements OnInit {

  public user: User;
  public waitingUsers: User[] = [];
  public waitingUsers$: Observable<User[]>;
  public gameName: string = "conecta4";
  public bottomActive: boolean = true;
  public waitingUserAlready$: Observable<boolean>;

  constructor(private waitingRoomService: WaitingRoomService) {
    this.user = new User("", "antonio@email.com", true);
    this.waitingUsers$ = new Observable<User[]>();
    this.waitingUserAlready$ = new Observable<boolean>();
  }

  ngOnInit(): void {
    this.bottomActive = true;    
    this.waitingRoomService.clear();
     this.waitingUsers$ = this.waitingRoomService.getUsers$();
     this.waitingUserAlready$ = this.waitingRoomService.getWaitingUserAlready$();
     this.waitingUsers$.subscribe(
      (users: User[]) => {
        this.waitingUsers = users;
      },
      (error: any) => {
         console.log(error.message);
      }
    );
     this.waitingRoomService.getWaitingUsers("conecta4");
  }

  introducedNick(user: User) {
     const waitingUser = new WaitingUser(user, "conecta4", true)
     this.waitingRoomService.addUser(waitingUser);
     this.waitingUserAlready$.subscribe(
       (flag) => {
         console.log("JAJAJAJAJAJ"); 
         if (flag) {               
            this.bottomActive = true;       
            waitingUser.introducedNick = false;
         } else {
           this.bottomActive = false;
           waitingUser.introducedNick = true;
         }
      }, 
        (error) => {
          console.log("ERROR: " + error.Message);
        }
      );
  } 

  ngOnDestroy() {
     const waitingUser: WaitingUser = new WaitingUser(this.user, "conecta4", true);
     this.waitingRoomService.removeUser(waitingUser);
  }
}
