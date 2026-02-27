import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListGroundComponent } from './list-ground/list-ground.component';
import { AddGroundComponent } from './add-ground/add-ground.component';
import { DeleteGroundComponent } from './delete-ground/delete-ground.component';

const routes: Routes = [
  {
    path: '',
    component: ListGroundComponent
  },
  {
    path:'viewGrounds',
    component: ListGroundComponent
  },
  {
    path: 'addGround',
    component: AddGroundComponent
  },
  {
    path: 'confirmDelete/:id',
    component: DeleteGroundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
