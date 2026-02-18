import { Event } from './event.model';

export interface Attendee {
  AttendeeId?: number;
  Name: string;
  Age: string;
  Email: string;
  EventId?: number;
  Event?: Event;
}
