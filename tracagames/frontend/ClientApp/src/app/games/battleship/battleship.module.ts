import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { BattleshipRoutingModule } from './battleship-routing.module';
import { BattleshipComponent } from './battleship.component';

const routes: Routes = [
  { path: '', component: BattleshipComponent }
];

@NgModule({
  declarations: [
    BattleshipComponent
  ],
  imports: [
    CommonModule,
    BattleshipRoutingModule,
    RouterModule.forChild(routes)
  ]
})
export class BattleshipModule { }
