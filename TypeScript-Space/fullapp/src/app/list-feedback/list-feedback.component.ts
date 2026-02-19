import { Component, OnInit } from '@angular/core';
import { FeedbackReport } from '../models/feedback-report.model';
import { FeedbackService } from '../services/feedback.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-feedback',
  templateUrl: './list-feedback.component.html',
  styleUrls: ['./list-feedback.component.css']
})
export class ListFeedbackComponent implements OnInit{

  feedbacks: FeedbackReport[] = [];

  constructor(public ser: FeedbackService, public rt: Router){}

  ngOnInit(): void {
      this.loadFeedbacks();
  }

  loadFeedbacks(){
    this.ser.showAll().subscribe(
      res => {this.feedbacks = res;}
    );
  }

  deleteFeedback(id: number){
    this.rt.navigate([`/confirmDelete`,id]);
  }

  updateFeedback(id: number){
    this.rt.navigate([`/updateFeedback`,id]);
  }
  



}
