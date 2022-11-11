import { WaitingUser } from './../../models/waitingUser/waiting-user';
import { User } from './../../models/user';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-waiting-room',
  templateUrl: './waiting-room.component.html',
  styleUrls: ['./waiting-room.component.css']
})
export class WaitingRoomComponent implements OnInit {

  @Input() gameName: string = "";
  @Input() user: User;
  @Input() waitingUsers: User[];
  @Input() bottomActive: boolean = true;
  @Output() introducedNick: EventEmitter<User> = new EventEmitter<User>();
  private waitingUser: WaitingUser;
  public nick: FormControl = new FormControl('');

  constructor() {
     this.waitingUsers = [];
     this.user = new User("", "", false);
     this.waitingUser = new WaitingUser(this.user, this.gameName, false);
  }

  ngOnInit(): void {
    this.waitingUser = new WaitingUser(this.user, this.gameName, false);
  }

  public isBottomActive(): boolean {
     return this.bottomActive;
  }

  public isIntroducedNick(): boolean {
     return this.waitingUser.isIntroducedNick();
  }

   public getUserName(user: User) {
      return user.userName;
   }

   public isMyUser(user: User) {
      return this.user == user;
   }

   public clickAceptar() {
      this.waitingUser.setNick(this.nick.value);
      this.user.userName = this.nick.value;
      this.introducedNick.emit(this.user);
   }
}
