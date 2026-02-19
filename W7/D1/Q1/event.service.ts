import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Event } from 'src/app/models/event.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  public apiUrl = "https://8080-ddefbdeaddeb342974523beecbcdone.premiumproject.examly.io";

  constructor(public http: HttpClient) { }

  addEvent(e: Event):Observable<Event>{
    return this.http.post<Event>(`${this.apiUrl}/api/Event`,e);
  }

  getEvents():Observable<Event[]>{
    return this.http.get<Event[]>(`${this.apiUrl}/api/Event`);
  }

  getEvent(id: number):Observable<Event>{
    return this.http.get<Event>(`${this.apiUrl}/api/Event/${id}`);
  }

  deleteEvent(id: number):Observable<Event>{
    return this.http.delete<Event>(`${this.apiUrl}/api/Event/${id}`);
  }

}
