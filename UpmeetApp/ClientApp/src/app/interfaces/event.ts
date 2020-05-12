export interface Event {
  id: number;
  title: string;
  description: string;
  eventDate: Date;
  eventLocation: string;
}



export interface JoinedEvent {
  id: number;
  eventID: number;
  userID: number;
  description: string;
  eventDate: Date;
  eventLocation: string;
}



export interface Favorite {
  id: number;
  eventID: number;
  userID: number;
}
