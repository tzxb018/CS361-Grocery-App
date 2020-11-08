import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserMenuService } from '../user-menu.service';

@Component({
  selector: 'app-user-menu',
  templateUrl: './user-menu.component.html',
  styleUrls: ['./user-menu.component.css'],
})

// component that handles all the grocery list instances
@Injectable({
  providedIn: 'root'
})
export class UserMenuComponent {

  // holds all the glists for the component
  public gLists: GList[];
  public allGLists: GList[];

  // constructor that populates the tables after injecting the http client and the base url 
  constructor(private userMenuService: UserMenuService) {
    this.refreshTable();
  }

  // function to reload the table
  refreshTable() {
    this.userMenuService.getAllGLists().subscribe(result => {
      this.gLists = result;
      this.allGLists = result;
      console.log(result);
    }, error => console.error(error));
  }

  // function to delete the glist from the table
  deleteGList(id: number, listName: string) {

    // if the user confirms to delete the glist (will be given the name of the list)
    if (confirm(`Are you sure to delete ${listName}?`)) {

      // deletes list by filtering through all glists and finding id if http delete passes
      this.userMenuService.deleteGList(id).subscribe(() => {
        this.gLists = this.gLists.filter(glist => glist.id != id);
      }, error => console.error(error));
    }
  }

  // function to search for glists
  searchGList() {
    const searchBar = document.getElementById("search") as HTMLInputElement;
    const listName = searchBar.value;
    if (listName.length > 0) {
      this.gLists = this.allGLists.filter(glist => glist.listName.includes(listName));
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
