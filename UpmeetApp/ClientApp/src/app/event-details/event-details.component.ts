import { Component, Input, OnInit } from '@angular/core';
import { EventService } from '../event.service';
import { FavoriteService } from '../favorites.service';
import { Event } from '../interfaces/event';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.scss']
})
/** EventDetails component*/
export class EventDetailsComponent implements OnInit{


  event: Event;
  id: number;
  @Input() ref: string;

  constructor(private eventData: EventService, private favoritesData: FavoriteService, private route:ActivatedRoute) { }
  /** EventDetails ctor */

  ngOnInit() {

    this.route.params.subscribe(params => {
      this.id = +params['id'];


      this.eventData.getEvent(this.id).subscribe(
        (data: Event) => this.event = { ...data },
        error => console.error(error)
      );
    })
  }

  add(id: number) {
    this.favoritesData.postFavorite(id).subscribe(
      (data: any) => console.log('success! ' + id), //TODO: change the button
      error => console.error(error)
    )
  }
}
