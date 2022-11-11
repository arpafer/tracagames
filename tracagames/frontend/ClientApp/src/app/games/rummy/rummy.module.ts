import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { RummyRoutingModule } from './rummy-routing.module';
import { RummyComponent } from './rummy.component';

const routes: Routes = [
  { path: '', component: RummyComponent }
];

@NgModule({
  declarations: [
    RummyComponent
  ],
  imports: [
    CommonModule,
    RummyRoutingModule,
    RouterModule.forChild(routes)
  ]
})
export class RummyModule { }
