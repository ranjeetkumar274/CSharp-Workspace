import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-countdown',
  templateUrl: './countdown.component.html',
  styleUrls: ['./countdown.component.css']
})
export class CountdownComponent implements OnInit {
  countdown: number = 0;
  intervalId: any;

  constructor() { }

  ngOnInit(): void {
  }

  startCountdown(seconds: number) {
    this.countdown = seconds;
    
    // Clear any existing interval to prevent multiple timers running at once
    if (this.intervalId) {
      clearInterval(this.intervalId);
    }

    this.intervalId = setInterval(() => {
      if (this.countdown > 0) {
        this.countdown--;
      } else {
        clearInterval(this.intervalId);
      }
    }, 1000);
  }
}



<div class="model-container">
  <h2>Count Fixer</h2>
  
  <input type="number" #seconds placeholder="Enter seconds">
  
  <button (click)="startCountdown(seconds.value)">
    Start Countdown
  </button>

  <span>{{ countdown }}</span>
</div>






