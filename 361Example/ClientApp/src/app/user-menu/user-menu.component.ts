import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-user-menu',
  templateUrl: './user-menu.component.html',
  styleUrls: ['./user-menu.component.css'],
})


export class UserMenuComponent {
  public gLists: GList[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<GList[]>(baseUrl + 'glist').subscribe(result => {
      this.gLists = result;
      console.log(result);
    }, error => console.error(error));
  }
}

interface GList {
  id: number;
  listName: string;
  date: Date;
  items: any;
  accountId: number;
}
