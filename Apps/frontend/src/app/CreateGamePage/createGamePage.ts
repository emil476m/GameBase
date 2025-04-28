import { Component } from '@angular/core';
import {ModalController} from "@ionic/angular";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {EnabledAIFeature} from "../Models/EnabledAIFeature";
import {AIResponsDto} from "../Models/AiResponsDto";
import {SearchDto} from "../Models/SearchDto";
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Serializer} from "@angular/compiler";
import {AiQuery} from "../Models/AiQuery";
import {CreateGameDto} from "../Models/CreateGameDto";
import {firstValueFrom} from "rxjs";

@Component({
  selector: 'app-create-game-page',
  templateUrl: 'createGamePage.html',
  styleUrls: ['createGamePage.scss'],
  standalone: false,
})
export class CreateGamePage {

  AIFeat : EnabledAIFeature = new EnabledAIFeature();

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
  AskAi = new FormControl("", Validators.required);
  AIresp = new AIResponsDto();
  constructor(private mc: ModalController, private http: HttpClient) {
    this.createyearlist()
    this.checkAiFunction()
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

  async createGameEntry()
  {
    const game : CreateGameDto = {
      name : this.gameTitle.value!,
      description : this.gameDesc.value!,
      imgUrl : this.imgUrl.value!,
      publishedYear : this.releseYear.value!,
    }

    const call = this.http.post(environment.baseURL+ 'CreateGame',game);
    const result = await firstValueFrom(call);
    if(result != undefined)
    {
      this.mc.dismiss(result);
    }
  }

  cancle()
  {
    this.mc.dismiss();
  }

  checkAiFunction()
  {
    const call = this.http.get<EnabledAIFeature>(environment.baseURL + "AiFeature");
    call.subscribe((resData: EnabledAIFeature) => {
      this.AIFeat.AiDescriptor = resData.AiDescriptor;
    });
  }

  AidescCall() {
    const query: AiQuery =
      {
        query: this.AskAi.value!,
      }
    const call = this.http.post<AIResponsDto>(environment.baseURL + "CreateAIDescription",query,);
    call.subscribe((resData: AIResponsDto) => {
      this.AIresp.response = resData.response;
    });
  }
}
