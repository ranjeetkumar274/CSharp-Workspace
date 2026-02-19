import { Component, OnInit } from '@angular/core';
import { FeedbackService } from '../services/feedback.service';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';
import { FeedbackReport } from '../models/feedback-report.model';

@Component({
  selector: 'app-add-feedback',
  templateUrl: './add-feedback.component.html',
  styleUrls: ['./add-feedback.component.css']
})
export class AddFeedbackComponent implements OnInit{

  obj: FeedbackReport = {
    id: 0,
    courseName: '',
    instructorName: '',
    startDate: ''
  }

  objid!: number;
  isEditMode: boolean = false;

  submitted: boolean = false;

  constructor(public ser: FeedbackService, public rt: Router, public ar: ActivatedRoute){}

  ngOnInit(): void {
      this.submitted = false;
      this.ar.params.subscribe(res =>{
        if(res['id']){
          this.isEditMode = true;
          this.objid = +res['id'];
          this.ser.getFeedbackById(this.objid).subscribe(
            data => {this.obj = data}
          );
        }
      }
      );
  }

  addFeedback(){
    if(this.isEditMode){
      this.ser.updateFeedback(this.objid, this.obj).subscribe(
        () => {this.rt.navigate([`/showFeedbacks`]);

        }
      );
    }else{
      this.submitted = true;
    this.ser.addFeedback(this.obj).subscribe(
      () => {this.rt.navigate([`/showFeedbacks`]);}
    );
    }
  }
}
