import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-user-menu',
  templateUrl: './user-menu.component.html',
  styleUrls: ['./user-menu.component.css'],
})


export class UserMenuComponent {
  public gLists: GList[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.getAllGLists();
  }

  getAllGLists() {
    this.http.get<GList[]>(this.baseUrl + 'glist').subscribe(result => {
      this.gLists = result;
      console.log(result);
    }, error => console.error(error));
  }

  deleteGList(id: number, listName: any) {

    if (confirm(`Are you sure to delete ${listName}?`)) {

      const url = this.baseUrl + `glist\\${id}`;

      console.log(url);
      this.http.delete<GList>(url).subscribe(
        res => console.log('http response', res),
        err => console.log('http error', err.error),
        () => console.log('http request complete')
      );

      console.log("reload...");

      this.gLists = this.gLists.filter(glist => glist.id != id);


    }
  }
}

interface GList {
  id: number;
  listName: string;
  date: Date;
  items: any;
  accountId: number;
}
