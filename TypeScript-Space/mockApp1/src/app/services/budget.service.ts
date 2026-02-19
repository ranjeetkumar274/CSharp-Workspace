import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Budget } from '../models/budget.model';

@Injectable({
  providedIn: 'root'
})
export class BudgetService {

  public apiUrl = "https://urban-space-computing-machine-7v9gpxwrv64x3x77r-3000.app.github.dev/budgets";

  constructor(public ser: HttpClient) { }

  getBudgets():Observable<Budget[]>{
    return this.ser.get<Budget[]>(`${this.apiUrl}`);
  }

  getBudget(id: number):Observable<Budget>{
    return this.ser.get<Budget>(`${this.apiUrl}/${id}`);
  }

  // deleteBudget(id: number){
  //   return this.ser.delete(`${this.apiUrl}/${id}`);
  // }

   postBudget(obj: Budget):Observable<Budget>{
    return this.ser.post<Budget>(`${this.apiUrl}`,obj);
  }

}
