import { Component, Inject, Injectable, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserMenuService } from '../user-menu.service';
import { DataService } from '../data.service';
import { ItemListService } from '../item-list.service';

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
  constructor(private userMenuService: UserMenuService, private dataService: DataService, private itemListService: ItemListService) {
    this.refreshTable();
  }

  selectGList(id: number, listName: string) {
    this.dataService.selectedGListId = id;
    this.dataService.selectedGListName = listName;
  }


  // function to reload the table
  async refreshTable() {

    const result = await this.userMenuService.getAllGLists().toPromise();
    this.allGLists = result;
    this.gLists = result;

    this.populateNumberOfItems();
  }

  // getting the number of items for each glist
  populateNumberOfItems() {

    // iterating through each glist 
    for (const glist of this.gLists) {

      // getting the respective glist id
      const glistID = glist.id;

      // waits for a response from function
      this.getItemsForEachList(glistID).then(function (result) {

        // result is a list of all the items in grocery list
        const numItems = result.length;

        // setting the respective html element for each grocery list
        if (numItems !== null) {
          const numLabel = document.getElementById("num" + glistID.toString());
          if (numLabel) {
            numLabel.innerHTML = numItems.toString();
          }
        }
      });

    }
  }

  // uses a promise to get the grocery items of each grocery list
  async getItemsForEachList(glistID: number) {
    return this.itemListService.getItemsForList(glistID).toPromise();
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
      this.gLists = this.allGLists.filter(glist => glist.listName.toLowerCase().includes(listName.toLowerCase()));
    }
    searchBar.value = "";
  }
}

interface GList {
  id: number;
  listName: string;
  date: Date;
  items: any;
  accountId: number;
}
