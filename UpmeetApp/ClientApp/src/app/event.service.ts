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
}
