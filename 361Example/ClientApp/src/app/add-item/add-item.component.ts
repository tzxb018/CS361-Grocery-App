import { Component, OnInit } from '@angular/core';
import { ItemListService } from '../item-list.service';
import { DataService } from '../data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent {

  constructor(private itemListService: ItemListService, private dataService: DataService, private router: Router) {
  }

  async addItem() {

    // getting the item's name and quantity from the user
    const newItemName = (document.getElementById('new-item-name') as HTMLInputElement).value;
    const newItemNum = Number((document.getElementById('new-item-num') as HTMLInputElement).value);

    // validating the inputs
    // checks to see if the item name has already been used
    let unique = true;

    // goes through the existing grocery lists of the user and checks if its been used
    this.dataService.existingItems.forEach(function (item) {
      if (item.name === (newItemName)) {
        unique = false;
      }
    });

    // checks to see if quantity value is valid (greater than 0)
    let numGood = false;
    if (newItemNum > 0 && Number.isInteger(newItemNum)) numGood = true;

    // validates the list name so that it only has letters and numbers
    const re = new RegExp('^[A-Za-z0-9 ]*[A-Za-z0-9][A-Za-z0-9 ]*$');

    // if the inputs are valid, then add item to list
    if (newItemName.match(re) && unique && numGood) {

      // getting grocery list id
      const gListID = this.dataService.selectedGListId;

      // getting the current date and time
      let todayUTC = new Date().getTime();

      // offset!
      let overlap = -6 * 60 * 60000;
      let todayCST = new Date(todayUTC + overlap);

      // creating the json that represents the new item
      const newItem = { name: newItemName, date: todayCST, checkoff: false, quantity: newItemNum, groceryListId: gListID };

      // sending the json to service to add to list
      await this.itemListService.addItem(newItem).toPromise().then(result => {

        // notify user that the item was successfully created and bring user back to list
        alert("Added " + newItemNum + " " + newItemName + " to your list!");
        this.router.navigateByUrl('/item-list');
      }
      );
    } else {

      // notify the user of the possible errors in the input they gave
      let errorOutput = "";
      if (!unique) {
        errorOutput = errorOutput + "This item name has already been used in this list!\n";
      }
      if (!newItemName.match(re)) {
        errorOutput = errorOutput + "This is an invalid name for the item. Only numbers and letters can be used!\n";
      }
      if (!numGood) {
        errorOutput = errorOutput + "The quantity needs to be an integer greater than 0!";
      }
      alert(errorOutput);
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
