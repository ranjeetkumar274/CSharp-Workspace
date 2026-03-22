import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Car } from '../models/car.model';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  public apiUrl = "https://urban-space-computing-machine-7v9gpxwrv64x3x77r-3000.app.github.dev/cars";

  constructor(public ser: HttpClient) { }

  getCars():Observable<Car[]>{
    console.log("hi1");
    return this.ser.get<Car[]>(`${this.apiUrl}`); 
  }

  addCar(carr: Car): Observable<Car>{
    return this.ser.post<Car>(`${this.apiUrl}`,carr);
  }

  getCarById(id: number): Observable<Car>{
    return this.ser.get<Car>(`${this.apiUrl}/${id}`)
  }

  deleteById(id: number): Observable<Car>{
    return this.ser.delete<Car>(`${this.apiUrl}/${id}`)
  }

  updateCarById(id: number, carr: Car): Observable<Car>{
    return this.ser.put<Car>(`${this.apiUrl}/${id}`,carr)
  }

}
