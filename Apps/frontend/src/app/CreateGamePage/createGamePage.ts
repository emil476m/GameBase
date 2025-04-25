import { Component } from '@angular/core';
import {ModalController} from "@ionic/angular";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-create-game-page',
  templateUrl: 'createGamePage.html',
  styleUrls: ['createGamePage.scss'],
  standalone: false,
})
export class CreateGamePage {

  gameTitle = new FormControl('',[ Validators.required, Validators.minLength(3), Validators.maxLength(250)]);
  releseYear = new FormControl('',[ Validators.required]);
  imgUrl = new FormControl('',[ Validators.required]);
  gameDesc = new FormControl('',[ Validators.required, Validators.minLength(250), Validators.maxLength(2500)]);

  game = new FormGroup({
    gameTitle: this.gameTitle,
    releseYear: this.releseYear,
    imgUrl: this.imgUrl,
    gameDesc: this.gameDesc,
  })

  yearlist : Array<string> = [];
  constructor(private mc: ModalController) {
    this.createyearlist()
  }


  createyearlist()
  {
    var currentyear = new Date().getFullYear();
    var endyear = 1958

    for(let i = currentyear; i >= endyear; i--)
    {
      var yearstr = i.toString()

      this.yearlist.push(yearstr);
    }
  }

  createGameEntry()
  {

  }

  cancle()
  {
    this.mc.dismiss();
  }
}
