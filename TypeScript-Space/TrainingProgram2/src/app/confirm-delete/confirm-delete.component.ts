import { Component, OnInit } from '@angular/core';
import { TrainingProgram } from '../models/trainingprogram.model';
import { TrainingprogramService } from '../services/trainingprogram.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-confirm-delete',
  templateUrl: './confirm-delete.component.html',
  styleUrls: ['./confirm-delete.component.css']
})
export class ConfirmDeleteComponent implements OnInit{
    tp: TrainingProgram = {
      id: 0,
      programName: '',
      department: '',
      description: '',
      isActive: false,
      startDate: '',
      endDate: '',
      trainerName: '',
      participantCount: 0
    }

    nid!: number;
  
    constructor(public ser: TrainingprogramService, public rt: Router, public ar: ActivatedRoute){}
  
    ngOnInit(): void {
        this.ar.params.subscribe(res => {
            this.nid = +res['id'];
            this.ser.getTrainingProgram(this.nid).subscribe(data => {this.tp = data})
          }
    )
    }

    confirmDelete(id: number){
      this.ser.deleteTrainingProgram(id).subscribe(
        () => setTimeout(() => {this.rt.navigate([`/viewTrainingPrograms`])},5000)
      )
    }
}
