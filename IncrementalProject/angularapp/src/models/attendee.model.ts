import { Event } from './event.model';

export interface Attendee {
  Attendeeld?: number;
  Name: string;
  Age: string;
  Email: string;
  Eventld?: number;
  Event?: Event;
}