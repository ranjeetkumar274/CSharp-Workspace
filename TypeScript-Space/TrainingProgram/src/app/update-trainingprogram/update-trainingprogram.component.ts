import { Component, OnInit } from '@angular/core';
import { TrainingProgram } from '../models/trainingProgram.model';
import { TrainingprogramService } from '../services/trainingprogram.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-trainingprogram',
  templateUrl: './update-trainingprogram.component.html',
  styleUrls: ['./update-trainingprogram.component.css']
})
export class UpdateTrainingprogramComponent implements OnInit{

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
  formSubmitted: boolean =false;

  constructor(public ser: TrainingprogramService, public rt: Router, public ar: ActivatedRoute){}

  ngOnInit(): void {
      this.ar.params.subscribe(
        res => {
          this.nid = +res['id']
          this.ser.getTrainingProgram(this.nid).subscribe(
            data => {this.tp = data}
          )
        }
      )
  }


  updateTrainingPrograms(){
    this.formSubmitted = true;
    this.ser.updateTrainingProgram(this.tp.id,this.tp).subscribe(
      () => {this.rt.navigate([`/viewTrainingPrograms`])}
    )
  }
}
