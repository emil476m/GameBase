import { Component } from '@angular/core';
import {ModalController} from "@ionic/angular";
import {CreateGamePage} from "../CreateGamePage/createGamePage";

@Component({
  selector: 'app-home-page',
  templateUrl: 'home-page.html',
  styleUrls: ['home-page.scss'],
  standalone: false,
})
export class HomePage {

  constructor(private mc: ModalController) {}


  openCreateGamePage() {
    this.mc.create({
      component: CreateGamePage,
      componentProps: {}
      }
    ).then(res => {
      res.present();
    });
  }
}
