import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FeedbackReport } from '../models/feedback-report.model';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {

  public apiUrl = "https://urban-space-computing-machine-7v9gpxwrv64x3x77r-3001.app.github.dev/feedbackReports";


  constructor(public http: HttpClient) { }

  showAll(): Observable<FeedbackReport[]>{
    return this.http.get<FeedbackReport[]>(`${this.apiUrl}`);
  }

  addFeedback(obj: FeedbackReport):Observable<FeedbackReport>{
    return this.http.post<FeedbackReport>(`${this.apiUrl}`,obj);
  }

  deleteFeedback(id: number): Observable<FeedbackReport>{
    return this.http.delete<FeedbackReport>(`${this.apiUrl}/${id}`);
  }

  getFeedbackById(id: number): Observable<FeedbackReport>{
    return this.http.get<FeedbackReport>(`${this.apiUrl}/${id}`);
  }

  updateFeedback(id: number, obj: FeedbackReport): Observable<FeedbackReport>{
    return this.http.put<FeedbackReport>(`${this.apiUrl}/${id}`,obj);
  }

}
