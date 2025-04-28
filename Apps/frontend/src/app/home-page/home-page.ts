import { Component } from '@angular/core';
import {ModalController} from "@ionic/angular";
import {CreateGamePage} from "../CreateGamePage/createGamePage";
import {GameDto} from "../Models/GameDto";
import {SearchDto} from "../Models/SearchDto";
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-home-page',
  templateUrl: 'home-page.html',
  styleUrls: ['home-page.scss'],
  standalone: false,
})
export class HomePage {

  gamelist: Array<GameDto> = [];

  constructor(private mc: ModalController, private http: HttpClient) {
    this.getgameList();
  }


  getgameList()
  {
    let page = 0
    if (this.gamelist.length > 0)
    {
      page == this.gamelist.length/10+1;
    }
    if(page == 0)
    {
      page = 1
    }
        try {
          this.gamelist = [];
          const call = this.http.get<GameDto[]>(environment.baseURL + "Games/" + 1);
          call.subscribe((resData: GameDto[]) => {
            if(page = 1)
            {
              this.gamelist = resData;
            }
            else
            {
              this.gamelist.concat(resData);
            }
            console.log(this.gamelist)
          })
        } catch (error) {
          // @ts-ignore
          if (error.status === 404) {
            console.log("could not find response for games");
          } else {
            console.error("Unexpected error " + error);
          }
        }
  }

  openCreateGamePage() {
    this.mc.create({
      component: CreateGamePage,
      componentProps: {}
      }
    ).then(res => {
      res.present();
    });
  }

  openDetailedGamePage(gameId: string)
  {
    window.location.href = "/game/" + gameId;
  }
}
