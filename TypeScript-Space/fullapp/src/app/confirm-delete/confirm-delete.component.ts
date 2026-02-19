import { Component, OnInit } from '@angular/core';
import { FeedbackService } from '../services/feedback.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FeedbackReport } from '../models/feedback-report.model';

@Component({
  selector: 'app-confirm-delete',
  templateUrl: './confirm-delete.component.html',
  styleUrls: ['./confirm-delete.component.css']
})
export class ConfirmDeleteComponent implements OnInit{

  obj: FeedbackReport = {
    id: 0,
    courseName: '',
    instructorName: '',
    startDate: ''
  }

  objid!: number;

  constructor(public ser: FeedbackService, public ar: ActivatedRoute, public rt: Router){}

  ngOnInit(): void {
      this.ar.params.subscribe(
        res => {this.objid = +res['id']
        this.ser.getFeedbackById(this.objid).subscribe(
          data => {this.obj = data}
        );
        }
      );
  }

  confirmDelete(id: number){
    this.ser.deleteFeedback(id).subscribe(
      () => {this.rt.navigate([`/showFeedbacks`]);}
    );
  }

  cancelDelete(){
    this.rt.navigate([`/showFeedbacks`]);
  }
}
