import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Event } from './interfaces/event';



@Injectable()
export class EventService {
  constructor(private http: HttpClient) {

  }



  getEvents() {
    return this.http.get<Event[]>('/api/event');
  }



  getEvent(id: number) {
    return this.http.get<Event>(`api/event/${id}`);
  }

  postEvent(newEvent: Event) {
    
    return this.http.post<Event>('/api/event', newEvent);
  }
}
