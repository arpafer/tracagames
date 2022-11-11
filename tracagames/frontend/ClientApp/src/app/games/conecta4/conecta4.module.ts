import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { AppModule } from './../../app.module';
import { WaitingRoomComponent } from './../waiting-room/waiting-room.component';
import { MaterialModule } from './../../material/material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { Conecta4RoutingModule } from './conecta4-routing.module';
import { Conecta4Component } from './conecta4.component';

const routes: Routes = [
  { path: '', component: Conecta4Component }
];

@NgModule({
  declarations: [
    Conecta4Component,
    WaitingRoomComponent
  ],
  imports: [
    CommonModule,
    Conecta4RoutingModule,
    RouterModule.forChild(routes),
    MaterialModule,
    ReactiveFormsModule
  ]
})
export class Conecta4Module { }
