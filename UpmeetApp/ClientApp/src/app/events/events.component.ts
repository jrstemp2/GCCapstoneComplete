import { Component, Input } from '@angular/core';
import { Event } from '../interfaces/event';
import { EventService } from '../event.service';
import { FavoriteService } from '../favorites.service';
@Component({
    selector: 'app-events',
    templateUrl: './events.component.html',
    styleUrls: ['./events.component.scss']
})
/** Events component*/
export class EventsComponent {
    /** Events ctor */
  constructor(private eventData: EventService, private favoritesData: FavoriteService) { }

  events: Event[];



  newEvent: Event;


  newTitle: string = "";
  newLocation: string = "";
  newDescription: string = "";
  dateString: string = "";
  newDate: Date = new Date();

  

  showForm: boolean = false;

  clearForm() {
    this.newTitle = "";
    this. newLocation = "";
    this.newDescription = "";
    this.dateString = "";
    this.newDate = new Date();
  }

  showAddForm() {
    if (this.showForm === false) {
      this.showForm = true;
    }
    else {
      this.showForm = false;
    }
  }

  loadPage() {
    this.eventData.getEvents().subscribe(
      (data: Event[]) => {
        this.events = data;
      },
      error => console.error(error)
    );
  }
  
  ngOnInit() {
    this.loadPage();
  }

  AddNewEvent() {
    this.eventData.postEvent({ id: 0, title: this.newTitle, description: this.newDescription, eventDate: this.newDate, eventLocation: this.newLocation } as Event)
      .subscribe(
        data => this.loadPage(),
        error => console.error(error)
      );

    

    this.clearForm();
    this.showForm = false;

  }
}
