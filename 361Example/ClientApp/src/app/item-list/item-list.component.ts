import { Component, Inject, Injectable, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ItemListService } from '../item-list.service';
import { DataService } from '../data.service';
import { UserMenuService } from '../user-menu.service';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css'],
})
@Injectable({
  providedIn: 'root'
})
export class ItemListComponent {

  // holds all the items for the component
  public items: Item[];
  public allItems: Item[];


  // constructor that populates the tables after injecting the http client and the base url 
  constructor(private itemListService: ItemListService, private dataService: DataService, private userMenuService: UserMenuService) {
    this.refreshTable();
    this.updateTimeStampOfList();

    var iframes = document.querySelectorAll('iframe');
    for (var i = 0; i < iframes.length; i++) {
      iframes[i].parentNode.removeChild(iframes[i]);
    }
  }

  // function to reload the table
  refreshTable() {
    if (this.dataService.selectedGListId) {
      console.log(this.dataService.selectedGListId);

      // from the selected grocery list id, retrieve the data from the service
      this.itemListService.getItemsForList(this.dataService.selectedGListId).subscribe(result => {

        // storing the items 
        this.items = result;
        this.allItems = result;
        this.dataService.existingItems = this.allItems;

        // sets the header of the page to the list's name
        document.getElementById("page-header").innerHTML = this.dataService.selectedGListName;
      }, error => console.error(error));
    }
  }

  // function to search for items
  searchItems() {
    const searchBar = document.getElementById("search") as HTMLInputElement;
    const itemName = searchBar.value;
    if (itemName.length > 0) {
      this.items = this.allItems.filter(glist => glist.name.toLowerCase().includes(itemName.toLowerCase()));
    }
  }

  // function to delete the items from the table
  deleteItem(id: number, itemName: string) {

    // if the user confirms to delete the glist (will be given the name of the list)
    if (confirm(`Are you sure to delete ${itemName}?`)) {

      // deletes list by filtering through all glists and finding id if http delete passes
      this.itemListService.deleteItem(id).subscribe(() => {
        this.items = this.items.filter(glist => glist.id != id);
      }, error => console.error(error));
    }
  }

  // function to update the grocery list object but keeping the same name
  updateTimeStampOfList() {

    // getting the current date and time
    let todayUTC = new Date().getTime();

    // offset!
    let overlap = -6 * 60 * 60000;
    let todayCST = new Date(todayUTC + overlap);

    // creates json object representing new list object
    const newList = {
      listName: this.dataService.selectedGListName,
      date: todayCST,
      items: null,
      accountId: this.dataService.selectedUserId
    };

    this.userMenuService.updateGList(newList, this.dataService.selectedGListId).subscribe(
      val => {
        console.log("PUT call successful value returned in body",
          val);
      },
      response => {
        console.log("PUT call in error", response);
      },
      () => {
        console.log("The PUT observable is now completed.");
      }
    );

    //subscribe((updated) => {
    //  console.log("updated glist timpestamp", updated);
    //  
    //  });
    //}, error => console.error(error));
  }
}

interface Item {
  id: number;
  name: string;
  date: Date;
  checkoff: boolean;
  quantity: number;
  groceryListId: number;
}
