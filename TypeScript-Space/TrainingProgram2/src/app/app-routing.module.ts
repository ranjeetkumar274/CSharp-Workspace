import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListTrainingprogramComponent } from './list-trainingprogram/list-trainingprogram.component';
import { AddTrainingprogramComponent } from './add-trainingprogram/add-trainingprogram.component';
import { ConfirmDeleteComponent } from './confirm-delete/confirm-delete.component';

const routes: Routes = [
  {
    path: '',
    component: ListTrainingprogramComponent
  },
  {
    path: 'viewTrainingPrograms',
    component: ListTrainingprogramComponent
  },
  {
    path: 'addTrainingProgram',
    component: AddTrainingprogramComponent
  },
  {
    path: 'updateTrainingProgram/:id',
    component: AddTrainingprogramComponent
  },
  {
    path: 'confirmDelete/:id',
    component: ConfirmDeleteComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
