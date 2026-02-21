import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Car } from 'src/app/models/car.model'

@Injectable({
  providedIn: 'root'
})
export class CarService {

  public apiUrl = "https://urban-space-computing-machine-7v9gpxwrv64x3x77r-3001.app.github.dev/cars";

  constructor(public http: HttpClient) { }

  addCar(obj : Car):Observable<Car>{
    return this.http.post<Car>(`${this.apiUrl}`,obj);
  }

  getCars():Observable<Car[]>{
    return this.http.get<Car[]>(`${this.apiUrl}`);
  }

  getCarById(id: number):Observable<Car>{
    return this.http.get<Car>(`${this.apiUrl}/${id}`);
  }

  deleteCar(id: number): Observable<Car>{
    return this.http.delete<Car>(`${this.apiUrl}/${id}`);
  }

  updateCar(id: number, obj: Car):Observable<Car>{
    return this.http.put<Car>(`${this.apiUrl}/${id}`,obj);
  }

}
