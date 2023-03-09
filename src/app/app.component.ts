import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { IBoardGame } from './interfaces/board-game';
import { RepositoryService } from './repository.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'BoardGameWebApp_2022';


  constructor(private repositoryService: RepositoryService) { }
  boardGames: any;
  gameTitle: string = "";
  description: string = "";
  yearPublished: number = -1;
  playerCount: number = -1


  ngOnInit(): void {
    this.gettGames();
  }

valdidateData(form: NgForm){
  alert("Bad data");
  // if all is good code

  this.addBoardGame(form)
}
  addBoardGame(form: NgForm) {
    let newGame: IBoardGame = {
      id: -1,
      title: form.form.value.title,
      description: form.form.value.description,
      yearPublished: form.form.value.yearPublished,
      recommendedPlayerCount: form.form.value.playerCount
    };


    this.repositoryService.addBoardGame(newGame).subscribe(
      () => {
        this.gettGames();
      }
    );
    form.resetForm();
  };


  gettGames() {
    this.repositoryService.getBoardGames().subscribe(
      (response) => {
        this.boardGames = response;
        // add alert
        // do calculation
      });
  }
}
