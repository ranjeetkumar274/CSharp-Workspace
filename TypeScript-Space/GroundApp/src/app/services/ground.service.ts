import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Ground } from '../models/ground.model';

@Injectable({
  providedIn: 'root'
})
export class GroundService {

  public apiUrl = "https://urban-space-computing-machine-7v9gpxwrv64x3x77r-3001.app.github.dev/grounds";

  constructor(public http: HttpClient) { }


  getAllGrounds():Observable<Ground[]>{
    return this.http.get<Ground[]>(`${this.apiUrl}`);
  }

  getGroundById(id: number): Observable<Ground>{
    return this.http.get<Ground>(`${this.apiUrl}/${id}`);
  }

  createGround(g: Ground):Observable<Ground>{
    return this.http.post<Ground>(`${this.apiUrl}`,g);
  }

  deleteGround(id: number): Observable<Ground>{
    return this.http.delete<Ground>(`${this.apiUrl}/${id}`);
  }


}
