import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Conecta4Component } from './conecta4.component';

const routes: Routes = [{ path: '', component: Conecta4Component }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class Conecta4RoutingModule { }
