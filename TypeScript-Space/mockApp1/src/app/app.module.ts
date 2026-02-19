import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BudgetListComponent } from './budget-list/budget-list.component';
import { AddBudgetComponent } from './add-budget/add-budget.component';
import { DeleteBudgetComponent } from './delete-budget/delete-budget.component';
import { HeaderComponent } from './header/header.component'

@NgModule({
  declarations: [
    AppComponent,
    BudgetListComponent,
    AddBudgetComponent,
    DeleteBudgetComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
