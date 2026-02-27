import { Component, OnInit } from '@angular/core';
import { TrainingprogramService } from '../services/trainingprogram.service';
import { Router } from '@angular/router';
import { TrainingProgram } from 'src/app/models/trainingprogram.model';

@Component({
  selector: 'app-list-trainingprogram',
  templateUrl: './list-trainingprogram.component.html',
  styleUrls: ['./list-trainingprogram.component.css']
})
export class ListTrainingprogramComponent implements OnInit{

  programs: TrainingProgram[] = [];
  total: number = 0;
  searchTerm: string = '';
  sortTerm: string = '';
  rangeTerm: any;

  constructor(public ser: TrainingprogramService, public rt : Router){}

  ngOnInit(): void {
      this.loadTrainingPrograms();
  }

  loadTrainingPrograms(){
    this.ser.getAllTrainingPrograms().subscribe(
      res => {this.programs = res;
      for(const p of this.programs){
        this.total = this.total + Number(p.participantCount);
      }
      }
    )
  }

  updateProgram(id: number){
    this.rt.navigate([`/updateTrainingProgram`,id]);
  }

  deleteProgram(id: number){
    this.rt.navigate([`/confirmDelete`,id]);
  }

  searchByName(){
    this.programs = this.programs.filter(a => a.programName.startsWith(this.searchTerm));
  }

  sortByName(){
    if(this.sortTerm === "asc"){
      this.programs = this.programs.sort((a,b) => a.id - b.id);
    }
    else if(this.sortTerm === "desc"){
      this.programs = this.programs.sort((a,b) => b.id - a.id);
    }
  }

  searchByRange(){
    if(this.rangeTerm == "o1"){
      this.programs = this.programs.filter(r => r.id >=1 && r.id <= 50)
    }
    else if(this.rangeTerm == "o2"){
      this.programs = this.programs.filter(r => r.id >=51 && r.id <= 100)
    }else{
      this.programs = this.programs.filter(r => r.id >=101)
    }
  }
}
