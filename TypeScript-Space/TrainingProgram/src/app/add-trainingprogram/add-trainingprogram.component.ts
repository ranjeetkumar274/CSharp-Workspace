import { Component, OnInit } from '@angular/core';
import { TrainingprogramService } from '../services/trainingprogram.service';
import { Router, RouteReuseStrategy } from '@angular/router';
import { TrainingProgram } from '../models/trainingProgram.model';

@Component({
  selector: 'app-add-trainingprogram',
  templateUrl: './add-trainingprogram.component.html',
  styleUrls: ['./add-trainingprogram.component.css']
})
export class AddTrainingprogramComponent implements OnInit{

  tp: TrainingProgram = {
    id: 0,
    programName: '',
    department: '',
    description: '',
    isActive: false,
    skillLevel: '',
    tags: ''
  }

  formSubmitted: boolean = false;

  constructor(public ser: TrainingprogramService, public rt: Router){}

  ngOnInit(): void {
      
  }

  addTrainingPrograms(){
    this.formSubmitted = true;
    this.ser.addTrainingProgram(this.tp).subscribe(
      () => {this.rt.navigate([`/viewTrainingPrograms`])}
    )
  }
}
