import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { IBoardGame } from './interfaces/board-game';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {
  [x: string]: any;

  constructor(private http: HttpClient) { }

  apiUri: string = 'https://boardgameangular-bwc.azurewebsites.net/'

  getBoardGames(){
    return this.http.get(this.apiUri);
  }
  addBoardGame(game:IBoardGame){
    return this.http.post(`${this.apiUri}/add`, game)
  }
}

