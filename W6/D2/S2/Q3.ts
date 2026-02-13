================================================================================
PROJECT: USER PROFILE CARD COMPONENT
================================================================================

--- FILE: user-profile-card.component.ts ---
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-profile-card',
  templateUrl: './user-profile-card.component.html',
  styleUrls: ['./user-profile-card.component.css']
})
export class UserProfileCardComponent implements OnInit {
  initialUserAge: number = 25;
  userName: string = 'John Doe';
  userAge: number = this.initialUserAge;

  constructor() { }

  ngOnInit(): void {
  }

  incrementAge(): void {
    this.userAge++;
  }

  resetAge(): void {
    this.userAge = this.initialUserAge;
  }

  updateUserName(newName: string): void {
    this.userName = newName;
  }
}

--- FILE: user-profile-card.component.html ---
<h2>User Profile</h2>
<p>Name: {{userName}}</p>
<p>Age: {{userAge}}</p>

<button (click)="incrementAge()">Increment Age</button>
<button (click)="resetAge()">Reset Age</button>

<label for="userNameInput">Edit User Name</label>
<input id="userNameInput" [value]="userName" (input)="updateUserName($event.target.value)">


================================================================================
PROJECT: TEXT TRANSFORMATION COMPONENT
================================================================================

--- FILE: text-transformation.component.ts ---
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-text-transformation',
  templateUrl: './text-transformation.component.html',
  styleUrls: ['./text-transformation.component.css']
})
export class TextTransformationComponent implements OnInit {
  transformedText: string = "";
  textLength: number = 0;
  lowercaseCount: number = 0;
  uppercaseCount: number = 0;
  numberCount: number = 0;
  specialCharCount: number = 0;

  transformText(inputText: string): void {
    this.transformedText = inputText.toUpperCase();
    this.textLength = inputText.length;
    
    this.lowercaseCount = 0;
    this.uppercaseCount = 0;
    this.numberCount = 0;
    this.specialCharCount = 0;

    for (let char of inputText) {
      if (char >= 'a' && char <= 'z') {
        this.lowercaseCount++;
      } else if (char >= 'A' && char <= 'Z') {
        this.uppercaseCount++;
      } else if (char >= '0' && char <= '9') {
        this.numberCount++;
      } else {
        this.specialCharCount++;
      }
    }
  }

  constructor() { }

  ngOnInit(): void {
  }
}

--- FILE: text-transformation.component.html ---
<div>
  <input type="text" (input)="transformText($event.target.value)" placeholder="Enter text here">
  
  <p>Transformed Text: {{ transformedText }}</p>
  <p>Length of Text: {{ textLength }}</p>
  <p>Lowercase Count: {{ lowercaseCount }}</p>
  <p>Uppercase Count: {{ uppercaseCount }}</p>
  <p>Number Count: {{ numberCount }}</p>
  <p>Special Character Count: {{ specialCharCount }}</p>
</div>
