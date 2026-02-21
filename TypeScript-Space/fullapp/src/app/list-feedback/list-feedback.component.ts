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
  filteredFeedbacks: FeedbackReport[] = [];
  searchTerm: string = '';

  constructor(public ser: FeedbackService, public rt: Router){}

  ngOnInit(): void {
      this.loadFeedbacks();
      this.searchTerm = '';
  }

  loadFeedbacks(){
    this.ser.showAll().subscribe(
      res => {this.feedbacks = res;
    this.filteredFeedbacks = this.feedbacks;
      }
    );
  }

  deleteFeedback(id: number){
    this.rt.navigate([`/confirmDelete`,id]);
  }

  updateFeedback(id: number){
    this.rt.navigate([`/updateFeedback`,id]);
  }

  searchFeedback(){
    if(this.searchTerm){
      this.filteredFeedbacks = this.feedbacks.filter(s => s.courseName.includes(this.searchTerm));
    }
    else{
      this.filteredFeedbacks = this.feedbacks;
    }
  }
  
  sortFeedbacks(){
    this.filteredFeedbacks = this.feedbacks.sort((a,b) => a.instructorName.localeCompare(b.instructorName));
  }



}
