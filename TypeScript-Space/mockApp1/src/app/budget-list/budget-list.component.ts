import { Component, OnInit } from '@angular/core';
import { BudgetService } from '../services/budget.service';
import { Router } from '@angular/router';
import { Budget } from '../models/budget.model';

@Component({
  selector: 'app-budget-list',
  templateUrl: './budget-list.component.html',
  styleUrls: ['./budget-list.component.css']
})
export class BudgetListComponent implements OnInit{

  budgets: Budget[] = [];

  ngOnInit(): void {
    this.loadBudgets();
  }

  constructor(public ser: BudgetService, public rt: Router){}

  loadBudgets(){
    this.ser.getBudgets().subscribe(r => {
      this.budgets = r;
      console.log('budgets:', this.budgets);
      if (this.budgets && this.budgets.length > 0) {
        console.log('category:', this.budgets[0].category);
      }
    });
  }

  
}
