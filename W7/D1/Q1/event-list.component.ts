import { Component, OnInit } from '@angular/core';
import { EventService } from '../services/event.service';
import { Router } from '@angular/router';
import { Event } from 'src/app/models/event.model';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {

  events: Event[] = [];
  filteredEvents: Event[] = [];
  searchTerm: string = '';

  constructor(public ser: EventService, public rt: Router) { }

  ngOnInit(): void {
    this.loadEvents();
    // this.filteredEvents = [];
    // this.searchTerm = '';
  }

  loadEvents(){
    this.ser.getEvents().subscribe(res => {
      this.events = res;
      this.filteredEvents = res;
    });
  }




  ========================================================================================================



  <!-- <h2>Events Data</h2> -->
<input type="text" id="search" [(ngModel)]="searchTerm"/>
<button class="search-button" id="search" (click)="searchEvents()">Search</button>
<table class="event-table">
    <thead>
        <tr >
        <!-- <th>Event ID</th> -->
        <th>Event Name</th>
        <th>Description</th>
        <th>Date</th>
        <th>Time</th>
        <th>Location</th>
        <th>Organizer</th>
        </tr>
    </thead>
    <tbody>
    <tr *ngFor="let e of filteredEvents" class="event-item">
        <!-- <td>{{e.eventId}}</td> -->
        <td>{{e.eventName}}</td>
        <td>{{e.eventDescription}}</td>
        <td>{{e.eventDate}}</td>
        <td>{{e.eventTime}}</td>
        <td>{{e.eventLocation}}</td>
        <td>{{e.eventOrganizer}}</td>
        <td><button id="delete" class="delete-button" (click)="deleteEvent(e.eventId)">Delete</button></td>
    </tr>
</tbody>
</table>

  deleteEvent(id: number){
    this.rt.navigate([`/confirmDelete`,id]);
  }


  searchEvents(){
    if(this.searchTerm){
      this.filteredEvents = this.events.filter(f => f.eventName.startsWith(this.searchTerm));
    }
    else{
      this.filteredEvents = this.events;
    }
  }

}
