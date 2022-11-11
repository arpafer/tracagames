import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SoccerbotComponent } from './soccerbot.component';

const routes: Routes = [{ path: '', component: SoccerbotComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SoccerbotRoutingModule { }
