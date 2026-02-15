import { Component } from '@angular/core';
import { Workout } from '../model/workout.model';

@Component({
  selector: 'app-fitness-tracker',
  templateUrl: './fitness-tracker.component.html',
  styleUrls: ['./fitness-tracker.component.css']
})
export class FitnessTrackerComponent {

  workouts : Workout[] = [];

  newExercise: string = "";
  newDuration: number = 30;

  
}
