================================================================================
PROJECT: ANGULAR TASK TRACKER (PARENT-CHILD ARCHITECTURE)
================================================================================

--- 1. CHILD COMPONENT: TASK INPUT ---
--- FILE: task-input.component.ts ---
import { Component, OnInit, Output } from '@angular/core';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-task-input',
  templateUrl: './task-input.component.html',
  styleUrls: ['./task-input.component.css']
})
export class TaskInputComponent implements OnInit {
  taskInput: string;
  constructor() { }

  ngOnInit(): void {
  }

  @Output() taskAdded: EventEmitter<string> = new EventEmitter<string>();

  addTask() {
    if(this.taskInput.trim().length > 0) {
      this.taskAdded.emit(this.taskInput);
      this.taskInput = "";
    }
  }
}

--- FILE: task-input.component.html ---
<div>
  <h1>Task Input</h1>
  <input type="text" [(ngModel)]="taskInput" />
  <button (click)="addTask()">Add Task</button>
</div>


--- 2. CHILD COMPONENT: TASK LIST ---
--- FILE: task-list.component.ts ---
import { Component, Input, OnInit, Output } from '@angular/core';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {
  @Input() tasks: string[];
  constructor() { }

  ngOnInit(): void {
  }

  @Output() taskDeleted: EventEmitter<number> = new EventEmitter<number>();

  deleteTask(index: number) {
    this.taskDeleted.emit(index);
  }
}

--- FILE: task-list.component.html ---
<div>
  <h1>Task List</h1>
  <ul>
    <li *ngFor="let t of tasks; let i = index">
      <p> {{ t }} </p>
      <button (click)="deleteTask(i)">Delete</button>
    </li>
  </ul>
</div>


--- 3. PARENT COMPONENT: APP COMPONENT ---
--- FILE: app.component.ts ---
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angularapp';
  tasks: string[] = [];

  addTask(task: string) {
    console.log(task);
    this.tasks.push(task);
  }

  deleteTask(index: number) {
    this.tasks.splice(index, 1);
  }
}

--- FILE: app.component.html ---
<div>
  <h1>Task Tracker</h1>
  <app-task-input (taskAdded)="addTask($event)"></app-task-input>
  <app-task-list [tasks]="tasks" (taskDeleted)="deleteTask($event)"></app-task-list>
</div>
