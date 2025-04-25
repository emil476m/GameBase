import {Component} from "@angular/core";
import {FormControl, Validators} from "@angular/forms";


@Component({
  selector: 'app-detailed-game-page',
  templateUrl: 'detailedGamePage.html',
  styleUrls: ['detailedGamePage.scss'],
  standalone: false,
})
export class DetailedGamePage {

  ratinglist : Array<number> = [];
  ratingcontrol =  new FormControl(0, [Validators.required,Validators.min(1), Validators.max(10)]);
  constructor() {
    this.createRatingList();
  }

  createRatingList()
  {
    for(let i = 1; i <= 10 ; i++)
    {
      this.ratinglist.push(i);
    }
  }
}
