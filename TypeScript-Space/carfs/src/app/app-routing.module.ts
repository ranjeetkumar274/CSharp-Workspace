import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListCarComponent } from './list-car/list-car.component';
import { AddCarComponent } from './add-car/add-car.component';
import { ConfirmDeleteComponent } from './confirm-delete/confirm-delete.component';

const routes: Routes = [
  {
    path: '',
    component: ListCarComponent
  },
  {
    path: 'viewCars',
    component: ListCarComponent
  },
    {
    path: 'addCar',
    component: AddCarComponent
  },
  {
    path: 'confirmDelete/:id',
    component: ConfirmDeleteComponent
  },
  {
    path: 'updateCar/:id',
    component: AddCarComponent
  },
  {
    path: '**',
    component: ListCarComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
