import { Byte } from "@angular/compiler/src/util";

export class Game {
   private _id: string;
   private _name: string;
   private _description: string;
   private _imageBase64: string;

   constructor(id: string, name: string, description: string, imageBase64: string) {
       this._id = id;
       this._name = name;
       this._description = description;
       this._imageBase64 = imageBase64;
   }

   public set id(id: string) {
      this._id = id;
   }

   public set name(theName: string) {
     this._name = theName;
   }

   public set description(_desc: string) {
      this._description = _desc;
   }

   public set imageBase64(_image: string) {
      this._imageBase64 = _image;
   }

   public getId(): string {
     return this._id;
   }
   
   public getName(): string {
      return this._name;
   }

   public getDescription(): string {
      return this._description;
   }

   public getImage(): string {
      return "data:image/jpeg;base64," + this._imageBase64;
   }
}
