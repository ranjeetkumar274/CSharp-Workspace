import { Component, OnInit } from '@angular/core';
import { TrainingProgram } from '../models/trainingprogram.model';
import { TrainingprogramService } from '../services/trainingprogram.service';
import { ActivatedRoute, Router } from '@angular/router';

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
    startDate: '',
    endDate: '',
    trainerName: '',
    participantCount: 0
  }

  formSubmitted: boolean = false;
  isEditMode: boolean = false;
  nid!: number;
  successMessage: string = '';

  constructor(public ser: TrainingprogramService, public rt: Router, public ar: ActivatedRoute){}

  ngOnInit(): void {
      this.ar.params.subscribe(res => {
        if(res['id']){
          this.isEditMode = true;
          this.nid = +res['id'];
          this.ser.getTrainingProgram(this.nid).subscribe(data => {this.tp = data})
        }
      })
  }

  addTrainingProgram(){
    if(this.isEditMode){
      this.ser.updateTrainingProgram(this.tp.id, this.tp).subscribe(
        () => setTimeout(() => {this.rt.navigate([`/viewTrainingPrograms`])},10000)
      )
    }else{
      if(this.tp.programName && this.tp.department && this.tp.startDate && this.tp.endDate){
      this.formSubmitted = true;
      this.tp.description = this.tp.isActive ? "descTrue" : "descFalse";
      this.successMessage = "Data submitted!";
      this.ser.addTrainingProgram(this.tp).subscribe(
      () => setTimeout(() => {this.rt.navigate([`/viewTrainingPrograms`])},5000)
    )
      }
    }  
  }
}
