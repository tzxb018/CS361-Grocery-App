import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css'],
})

export class ItemListComponent {

  public items: Item[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Item[]>(baseUrl + 'items').subscribe(result => {
      this.items = result;
      console.log(result);
    }, error => console.error(error));
  }
}

interface Item {
  id: number;
  name: string;
  date: Date;
  checkoff: boolean;
}
