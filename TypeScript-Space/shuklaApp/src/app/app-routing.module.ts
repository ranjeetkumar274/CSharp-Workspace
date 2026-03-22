import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShowCarComponent } from './show-car/show-car.component';
import { AddCarComponent } from './add-car/add-car.component';
import { ConfirmDeleteComponent } from './confirm-delete/confirm-delete.component';

const routes: Routes = [
  {path: "viewCars", component: ShowCarComponent},
  {path: "addCar", component: AddCarComponent},
  {path: "confirm-delete/:id", component: ConfirmDeleteComponent},
  {path: "editCar/:id", component: AddCarComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
