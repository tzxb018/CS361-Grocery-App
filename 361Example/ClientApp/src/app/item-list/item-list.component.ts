import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ItemListService } from '../item-list.service';

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
  constructor(private itemListService: ItemListService) {
    this.refreshTable();
  }

  // function to reload the table
  refreshTable() {
    this.itemListService.getAllItems().subscribe(result => {
      this.items = result;
      this.allItems = result;
      console.log(result);
    }, error => console.error(error));
  }

  // function to search for items
  searchItems() {
    const searchBar = document.getElementById("search") as HTMLInputElement;
    const itemName = searchBar.value;
    if (itemName.length > 0) {
      this.items = this.allItems.filter(glist => glist.name.includes(itemName));
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
