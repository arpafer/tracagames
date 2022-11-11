export class User {
   public userName: string;
   public email: string;
   public logged: boolean;
   public password: string;

   constructor(userName: string, email: string, logged: boolean, password: string = "") {
     this.userName = userName;
     this.email = email;
     this.logged = logged;
     this.password = password;
   }
/*
   public set userName(value: string) {
      this._userName = value;
   }

   public get userName(): string {
      return this._userName;
   }

   public set email(value: string) {
      this._email = value;
   }

   public get email(): string {
      return this._email;
   }

   public set logged(value: boolean) {
     this._logged = value;
   }

   public get logged(): boolean {
     return this._logged;
   }

   public set password(value: string) {
     this._password = value;
   }

   public get password(): string {
      return this._password;
   }
   */
}
