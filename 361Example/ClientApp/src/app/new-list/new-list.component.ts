import { Component, Inject, Input, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-new-list',
  templateUrl: './new-list.component.html',
  styleUrls: ['./new-list.component.css'],

})
export class NewListComponent {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  addGList() {
    const newListName = (document.getElementById('new-list-name') as HTMLInputElement).value;
    console.log('new list name', newListName);
    let todayUTC = new Date().getTime();
    let overlap = -5 * 60 * 60000;
    let todayCST = new Date(todayUTC + overlap);
    const newList = { listName: newListName, date: todayCST, items: null, accountId: 1 };

    this.http.post<GList>(this.baseUrl + 'glist', newList).subscribe(
      res => console.log('http response', res),
      err => console.log('http error', err.error),
      () => console.log('http request complete')
    );


  }


}

interface GList {
  id: number;
  listName: string;
  date: Date;
  items: any;
  accountId: number;
}
