import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BudgetListComponent } from './budget-list/budget-list.component';
import { DeleteBudgetComponent } from './delete-budget/delete-budget.component';
import { AddBudgetComponent } from './add-budget/add-budget.component';

const routes: Routes = [
  {path: '', component: BudgetListComponent},
  {path: 'budgets', component: BudgetListComponent},
  // {path: 'delete-budget/:id', component: DeleteBudgetComponent},
  {path: 'add-budget', component: AddBudgetComponent},
  {path: '**', component: BudgetListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
