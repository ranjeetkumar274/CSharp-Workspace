import { Component, OnInit } from '@angular/core';

interface Task{
  description: string;
  dueDate: string;
  priority: number;
  completed: boolean;
}


@Component({
  selector: 'app-task-manager',
  templateUrl: './task-manager.component.html',
  styleUrls: ['./task-manager.component.css']
})
export class TaskManagerComponent implements OnInit{

  ngOnInit(): void {
      
  }

  constructor(){}

  tasks: Task[] = [];

  currDescription: string = '';
  currDueDate: string = '';
  currPriority: number = 2;


  addTask(){
    if(this.currDescription.trim() !== '' && this.currDueDate.trim() !== '' && this.currPriority >= 1 && this.currPriority <= 3){
      this.tasks.push({
        description: this.currDescription,
        dueDate: this.currDueDate,
        priority: this.currPriority,
        completed: false
      });

      this.currDescription = '';
      this.currDueDate = '';
      this.currPriority = 2;
    }
  }


  toggleCompleted(index: number){
    this.tasks[index].completed = !this.tasks[index].completed;
  }


  removeTask(index: number){
    this.tasks.splice(index,1);
  }

}
