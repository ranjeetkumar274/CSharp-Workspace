import { Component, OnInit } from '@angular/core';
import { TrainingprogramService } from '../services/trainingprogram.service';
import { ActivatedRoute, Router } from '@angular/router';
import { TrainingProgram } from '../models/trainingProgram.model';

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
    skillLevel: '',
    tags: ''
  }

  nid!: number;

  constructor(public ser: TrainingprogramService, public rt: Router, public ar: ActivatedRoute){}

  ngOnInit(): void {
      this.ar.params.subscribe(
        res => {
          this.nid = +res['id'];
          this.ser.getTrainingProgram(this.nid).subscribe(
            data => {this.tp = data}
          )
        }
      )
  }

  confirmDelete(id: number){
    this.ser.deleteTrainingProgram(id).subscribe(
      () => {this.rt.navigate([`/viewTrainingPrograms`])}
    )
  }

  cancelDelete(){
    this.rt.navigate([`/viewTrainingPrograms`])
  }
}
