import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { SoccerbotRoutingModule } from './soccerbot-routing.module';
import { SoccerbotComponent } from './soccerbot.component';

const routes: Routes = [
  { path: '', component: SoccerbotComponent }
];

@NgModule({
  declarations: [
    SoccerbotComponent
  ],
  imports: [
    CommonModule,
    SoccerbotRoutingModule,
    RouterModule.forChild(routes)
  ]
})
export class SoccerbotModule { }
