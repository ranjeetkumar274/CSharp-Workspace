import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-countdown',
  templateUrl: './countdown.component.html',
  styleUrls: ['./countdown.component.css']
})
export class CountdownComponent implements OnInit{
  countdown: number=0;
  intervalId: any;
  constructor(){

  }
  startCountdown(seconds:number){
    this.countdown=seconds;
    this.intervalId=setInterval(()=>{
      if(this.countdown>0){
        this.countdown--;
      }
      else{
        clearInterval(this.intervalId);
      }
    },1000)
  }
  ngOnInit(): void {
    
  }

}




<div class="model-container">
    <h2>Count Fixer</h2>
    <input type="number" #seconds>
    <button (click)="startCountdown(seconds.valueAsNumber)">Start Countdown</button>
    <span>{{countdown}}</span>
</div>






