import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TrainingProgram } from '../models/trainingProgram.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TrainingprogramService {

  public apiUrl = "https://urban-space-computing-machine-7v9gpxwrv64x3x77r-3001.app.github.dev/trainingPrograms";

  constructor(public http : HttpClient) { }

  addTrainingProgram(t : TrainingProgram): Observable<TrainingProgram>{
    return this.http.post<TrainingProgram>(`${this.apiUrl}`,t);
  }

  getTrainingPrograms():Observable<TrainingProgram[]>{
    return this.http.get<TrainingProgram[]>(`${this.apiUrl}`);
  }

  getTrainingProgram(id: number):Observable<TrainingProgram>{
    return this.http.get<TrainingProgram>(`${this.apiUrl}/${id}`);
  }

  updateTrainingProgram(id: number, tp: TrainingProgram): Observable<TrainingProgram>{
    return this.http.put<TrainingProgram>(`${this.apiUrl}/${id}`,tp);
  }

  deleteTrainingProgram(id: number): Observable<TrainingProgram>{
    return this.http.delete<TrainingProgram>(`${this.apiUrl}/${id}`);
  }

}
