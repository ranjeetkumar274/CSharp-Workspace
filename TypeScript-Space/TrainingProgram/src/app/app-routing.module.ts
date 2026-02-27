import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListTrainingprogramsComponent } from './list-trainingprograms/list-trainingprograms.component';
import { AddTrainingprogramComponent } from './add-trainingprogram/add-trainingprogram.component';
import { ConfirmDeleteComponent } from './confirm-delete/confirm-delete.component';
import { UpdateTrainingprogramComponent } from './update-trainingprogram/update-trainingprogram.component';

const routes: Routes = [
  {
    path:'',
    component: ListTrainingprogramsComponent
  },
  {
    path:'viewTrainingPrograms',
    component: ListTrainingprogramsComponent
  },
  {
    path:'addTrainingProgram',
    component: AddTrainingprogramComponent
  },
  {
    path: 'updateTrainingProgram/:id',
    component: UpdateTrainingprogramComponent
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
