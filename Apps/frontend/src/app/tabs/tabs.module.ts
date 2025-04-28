import { IonicModule } from '@ionic/angular';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import { TabsPageRoutingModule } from './tabs-routing.module';

import { TabsPage } from './tabs.page';
import {SearchPage} from "../search-page/search-page";
import {HomePage} from "../home-page/home-page";
import {CreateGamePage} from "../CreateGamePage/createGamePage";
import {DetailedGamePage} from "../detailedGamePage/detailedGamePage";

@NgModule({
  imports: [
    IonicModule,
    CommonModule,
    FormsModule,
    TabsPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [TabsPage, HomePage, SearchPage, CreateGamePage, DetailedGamePage],
})
export class TabsPageModule {}
