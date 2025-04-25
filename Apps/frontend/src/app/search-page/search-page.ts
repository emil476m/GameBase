import { Component } from '@angular/core';

@Component({
  selector: 'app-search-page',
  templateUrl: 'search-page.html',
  styleUrls: ['search-page.scss'],
  standalone: false,
})
export class SearchPage {

  gamelist : Array<any> = []

  constructor() {}

  search()
  {

  }
}
