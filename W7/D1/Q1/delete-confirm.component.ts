import { Component, OnInit } from '@angular/core';
import { EventService } from '../services/event.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Event } from 'src/app/models/event.model';

@Component({
  selector: 'app-delete-confirm',
  templateUrl: './delete-confirm.component.html',
  styleUrls: ['./delete-confirm.component.css']
})
export class DeleteConfirmComponent implements OnInit {

  eventid: number;
  event: Event = {
    eventId: 0,
    eventName: '',
    eventDescription: '',
    eventDate: '',
    eventTime: '',
    eventLocation: '',
    eventOrganizer: ''
  }

  constructor(public ser: EventService, public ar: ActivatedRoute, public rt: Router) { }

  ngOnInit(): void {
    this.ar.params.subscribe(
      res => {
        this.eventid = +res['id']
        this.ser.getEvent(this.eventid).subscribe(
          data => {this.event = data}
        );
      }
    )
  }

  confirmDelete(eventId: number){
      this.ser.deleteEvent(eventId).subscribe(() => {this.rt.navigate([`/viewEvents`])});

    
  }

  cancelDelete(){
    this.rt.navigate([`/viewEvents`]);
  }

}




=================================================================================================================





<h2>Delete Confirmation</h2>

<label>Event Name: </label>
<p>{{event.eventName}}</p>
<label>Event Description: </label>
<p>{{event.eventDescription}}</p>
<label>Event Date: </label>
<p>{{event.eventDate}}</p>
<label>Event Time: </label>
<p>{{event.eventTime}}</p>
<label>Event Location: </label>
<p>{{event.eventLocation}}</p>
<label>Event Organizer: </label>
<p>{{event.eventOrganizer}}</p>

<button class="confirm-button" type="button" (click)="confirmDelete(event.eventId)">Confirm Delete</button>
<button class="cancel-button" type="button" (click)="cancelDelete()">Cancel Delete</button>
