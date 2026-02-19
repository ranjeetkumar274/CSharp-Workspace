import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListFeedbackComponent } from './list-feedback/list-feedback.component';
import { AddFeedbackComponent } from './add-feedback/add-feedback.component';
import { ConfirmDeleteComponent } from './confirm-delete/confirm-delete.component';

const routes: Routes = [
  {
    path: '',
    component: ListFeedbackComponent
  },
  {
    path: 'showFeedbacks',
    component: ListFeedbackComponent
  },
  {
    path: 'addFeedback',
    component: AddFeedbackComponent
  },
  {
    path: 'confirmDelete/:id',
    component: ConfirmDeleteComponent
  },
  {
    path: 'updateFeedback/:id',
    component: AddFeedbackComponent
  },
  {
    path: '**',
    component: ListFeedbackComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
