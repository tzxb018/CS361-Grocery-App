import { Component, Inject, Injectable, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ItemListService } from '../item-list.service';
import { DataService } from '../data.service';

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
  constructor(private itemListService: ItemListService, private dataService: DataService) {
    this.refreshTable();
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
}

interface Item {
  id: number;
  name: string;
  date: Date;
  checkoff: boolean;
  quantity: number;
  groceryListId: number;
}
