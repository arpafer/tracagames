import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RummyComponent } from './rummy.component';

const routes: Routes = [{ path: '', component: RummyComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RummyRoutingModule { }
