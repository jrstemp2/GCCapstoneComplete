import { Component } from '@angular/core';
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

  ngOnInit() {
    this.eventData.getEvents().subscribe(
      (data: Event[]) => {
        this.events = data;
      },
      error => console.error(error)
    );
  }
}
