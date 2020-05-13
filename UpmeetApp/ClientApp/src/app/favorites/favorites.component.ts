import { Component } from '@angular/core';
import { FavoriteService } from '../favorites.service';
import { Event, JoinedEvent, Favorite } from '../interfaces/event';

@Component({
    selector: 'app-favorites',
    templateUrl: './favorites.component.html',
    styleUrls: ['./favorites.component.scss']
})
/** favorites component*/
export class FavoritesComponent {
    /** favorites ctor */
  constructor(private favoritesData: FavoriteService) { }

  favorites: JoinedEvent[];

  ngOnInit() {
    this.get();
  }

  delete(id: number) {
    this.favoritesData.deleteFavorite(id).subscribe(
      (data: any) => {
        console.log(data);
        this.get();
      },
      error => console.error(error)
    );
  }

  get() {
    this.favoritesData.getFavorites().subscribe(
      (data: JoinedEvent[]) => {
        this.favorites = data;
      },
      error => console.error(error)
    );
  }
}
