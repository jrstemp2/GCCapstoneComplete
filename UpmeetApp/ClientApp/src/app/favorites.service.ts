import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Favorite, JoinedEvent } from './interfaces/event';



@Injectable()
export class FavoriteService {
  userID: number;


  constructor(private http: HttpClient) {
    this.userID = 1;
  }

  getFavorites() {
    return this.http.get<JoinedEvent[]>('/api/favorite/');
  }

  deleteFavorite(favID: number) {
    return this.http.delete('/api/favorite/' + favID);
  }

  postFavorite(eventID: number) {
    let event: Favorite = {
      id: 0,
      userID: this.userID,
      eventID: eventID,
    };
    return this.http.post<Favorite>('/api/favorite', event);
  }
}
