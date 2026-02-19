import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EventListComponent } from './event-list/event-list.component';
import { EventFormComponent } from './event-form/event-form.component';
import { DeleteConfirmComponent } from './delete-confirm/delete-confirm.component';

const routes: Routes = [
  {path: '', component: EventListComponent},
  {path: 'viewEvents', component: EventListComponent},
  {path: 'addNewEvent', component: EventFormComponent},
  {path: 'confirmDelete/:id',component: DeleteConfirmComponent},
  {path: '**',component:EventListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
