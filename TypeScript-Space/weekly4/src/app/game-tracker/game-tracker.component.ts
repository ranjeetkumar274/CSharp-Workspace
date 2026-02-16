import { Component } from '@angular/core';

interface Game{
  title: string;
  platform: string;
  hoursPlayed: number;
  completed: boolean;
}

@Component({
  selector: 'app-game-tracker',
  templateUrl: './game-tracker.component.html',
  styleUrls: ['./game-tracker.component.css']
})
export class GameTrackerComponent {
  
  games: Game[] = [];

  currGameTitle: string = '';
  currPlatform: string = '';
  currHoursPlayed: number = 0;

  addGame(){
    if(this.currGameTitle.trim() !== '' && this.currPlatform.trim() !== '' && this.currHoursPlayed > 0){
      this.games.push({
        title: this.currGameTitle,
        platform: this.currPlatform,
        hoursPlayed: this.currHoursPlayed,
        completed: false
      });

      this.currGameTitle = '';
      this.currPlatform = '';
      this.currHoursPlayed = 0;
    }
  }
  

  toggleCompleted(index: number){
    this.games[index].completed = !this.games[index].completed;
  }

  removeGame(index: number){
    this.games.splice(index,1);
  }
}
