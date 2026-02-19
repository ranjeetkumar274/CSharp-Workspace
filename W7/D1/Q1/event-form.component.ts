import { Component, OnInit } from '@angular/core';
import { EventService } from '../services/event.service';
import { Router } from '@angular/router';
import { Event } from 'src/app/models/event.model'

@Component({
  selector: 'app-event-form',
  templateUrl: './event-form.component.html',
  styleUrls: ['./event-form.component.css']
})
export class EventFormComponent implements OnInit {

  ev: Event = {
    eventId: 0,
    eventName: '',
    eventDescription: '',
    eventDate: '',
    eventTime: '',
    eventLocation: '',
    eventOrganizer: ''
  };

  formSubmitted: boolean = false;

  constructor(public ser: EventService, public rt: Router) { }

  ngOnInit(): void {
    console.log(this.ev.eventDate);
  }

  addEvent(){
    this.formSubmitted = true;
    this.ser.addEvent(this.ev).subscribe(() => this.rt.navigate([`/viewEvents`]));
    
  }

}





===============================================================================================================



  


  <form (ngSubmit)="addEvent()" #eventForm="ngForm" >
    <div>
        <label>Event Name:</label>
        <input type="text" id="eventName" name="eventName" [(ngModel)]="ev.eventName" required/>
        <div class="error-message" *ngIf="eventForm.submitted && !ev.eventName" style="color: red;">Event Name is required</div>
    </div>

    <div>
        <label>Event Description:</label>
        <input type="text" id="eventDescription" name="eventDescription" [(ngModel)]="ev.eventDescription" required/>
        <div class="error-message" *ngIf="eventForm.submitted && !ev.eventDescription" style="color: red;">Event Description is required</div>
    </div>

    <div>
        <label>Event Date:</label>
        <input type="text" id="eventDate" name="eventDate" [(ngModel)]="ev.eventDate" required/>
        <div class="error-message" *ngIf="eventForm.submitted && !ev.eventDate" style="color: red;">Event Date is required</div>
    </div>

    <div>
        <label>Event Time:</label>
        <input type="text" id="eventTime" name="eventTime" [(ngModel)]="ev.eventTime" required/>
        <div class="error-message" *ngIf="eventForm.submitted && !ev.eventTime" style="color: red;">Event Time is required</div>
    </div>

    <div>
        <label>Event Location:</label>
        <input type="text" id="eventLocation" name="eventLocation" [(ngModel)]="ev.eventLocation" required/>
        <div class="error-message" *ngIf="eventForm.submitted && !ev.eventLocation" style="color: red;">Event Location is required</div>
    </div>

    <div>
        <label>Event Organizer:</label>
        <input type="text" id="eventOrganizer" name="eventOrganizer" [(ngModel)]="ev.eventOrganizer" required/>
        <div class="error-message" *ngIf="eventForm.submitted && !ev.eventOrganizer" style="color: red;">Event Organizer is required</div>
    </div>

    <button type="submit" (click)="addEvent()">Add Event</button>
</form>
