import {Component} from "@angular/core";
import {FormControl, Validators} from "@angular/forms";
import {SearchDto} from "../Models/SearchDto";
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {firstValueFrom} from "rxjs";
import {ActivatedRoute} from "@angular/router";
import {GameDto} from "../Models/GameDto";
import {CreateReviewDto} from "../Models/CreateReviewDto";
import {ReviewDto} from "../Models/ReviewDto";


@Component({
  selector: 'app-detailed-game-page',
  templateUrl: 'detailedGamePage.html',
  styleUrls: ['detailedGamePage.scss'],
  standalone: false,
})
export class DetailedGamePage {

  ratinglist : Array<number> = [];
  ratingcontrol =  new FormControl(0, [Validators.required,Validators.min(1), Validators.max(10)]);


  gameTitle = new FormControl('',[ Validators.required, Validators.minLength(3), Validators.maxLength(250)]);
  releaseYear = new FormControl('',[ Validators.required]);
  imgUrl = new FormControl('',[ Validators.required]);
  gameDesc = new FormControl('',[ Validators.required, Validators.minLength(250), Validators.maxLength(2500)]);
  gameScore = new FormControl('',[ Validators.required, Validators.min(0), Validators.max(10)]);


  constructor(private http: HttpClient, private route: ActivatedRoute) {
    this.createRatingList();
  }
  ngOnInit() {
    this.getGameData();
    this.getGameScore();
  }

  createRatingList()
  {
    for(let i = 1; i <= 10 ; i++)
    {
      this.ratinglist.push(i);
    }
  }

  async getGameData(){
    try {
      const call = this.http.get<GameDto>(environment.baseURL + "Game/" + this.route.snapshot.paramMap.get('gameId'));
      const result = await firstValueFrom<GameDto>(call);

      this.gameTitle.setValue(result.gameName);
      this.releaseYear.setValue(result.gamePublishedYear);
      this.imgUrl.setValue(result.gameImgUrl);
      this.gameDesc.setValue(result.gameDescription);


    } catch (error) {
      // @ts-ignore
      if (error.status === 404) {
        console.log("could not find response");
      } else {
        console.error("Unexpected error " + error);
      }
    }
  }

  async getGameScore(){
    try {
      const call = this.http.get<ReviewDto>(environment.baseURL + "ReviewScore/" + this.route.snapshot.paramMap.get('gameId'));
      const result = await firstValueFrom<ReviewDto>(call);

      this.gameScore.setValue(result.gameScore.toString());

    } catch (error) {
      // @ts-ignore
      if (error.status === 404) {
        console.log("could not find response");
      } else {
        console.error("Unexpected error " + error);
      }
    }
  }

  async createReview(){
    try {
      const review : CreateReviewDto = {
        game_id : this.route.snapshot.paramMap.get('gameId')!,
        score : this.ratingcontrol.value!,
      }

      const call = this.http.post<ReviewDto>(environment.baseURL + "ReviewScore", review);
      const result = await firstValueFrom<ReviewDto>(call);

      this.gameScore.setValue(result.gameScore.toString());

    } catch (error) {
      // @ts-ignore
      if (error.status === 404) {
        console.log("could not find response");
      } else {
        console.error("Unexpected error " + error);
      }
    }
  }
}
