import { Component, OnInit } from '@angular/core';
import { TrainingprogramService } from '../services/trainingprogram.service';
import { Router } from '@angular/router';
import { TrainingProgram } from '../models/trainingProgram.model';

@Component({
  selector: 'app-list-trainingprograms',
  templateUrl: './list-trainingprograms.component.html',
  styleUrls: ['./list-trainingprograms.component.css']
})
export class ListTrainingprogramsComponent implements OnInit{

  trainingprograms: TrainingProgram[] = [];
  filteredTrainings: TrainingProgram[] = [];

  searchTerm: string = '';

  ss: boolean = false;

  constructor(public ser: TrainingprogramService, public rt: Router){}

  ngOnInit(): void {
      this.loadTrainingPrograms();
      this.searchTerm = '';
  }

  loadTrainingPrograms(){
    this.ser.getTrainingPrograms().subscribe(
      res => {this.trainingprograms = res;
        this.filteredTrainings = this.trainingprograms;
      }
    )
  }


  deleteTrainingProgram(id: number){
    this.rt.navigate([`/confirmDelete`,id]);
  }

  updateTrainingProgram(id: number){
    this.rt.navigate([`/updateTrainingProgram`,id]);
  }

  searchByName(){
    if(this.searchTerm){
      this.filteredTrainings = this.trainingprograms.filter(a => a.programName.includes(this.searchTerm));
    }
  }

  sortBySkill(){
    this.filteredTrainings = this.trainingprograms.sort((a,b) => a.skillLevel.localeCompare(b.skillLevel));
  }

  searchByStatus(){
    this.filteredTrainings = this.trainingprograms.filter(a => a.isActive === this.ss);
  }
  
}
