import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserMenuService } from '../user-menu.service';
import { DataService } from '../data.service';
@Component({
  selector: 'app-new-list',
  templateUrl: './new-list.component.html',
  styleUrls: ['./new-list.component.css'],

})
export class NewListComponent {


  constructor(private userMenuService: UserMenuService, private router: Router, private dataService: DataService) {

  }

  async addGList() {

    // gets the new list name from the input box
    const newListName = (document.getElementById('new-list-name') as HTMLInputElement).value;

    // checks to see if the list name has already been used
    let unique = true;

    // goes through the existing grocery lists of the user and checks if its been used
    this.dataService.existingGLists.forEach(function (glist) {
      if (glist.listName === (newListName)) {
        unique = false;
      }
    });

    // checks to see if list name is not too long
    let goodSize = false;
    if (newListName.length <= 25) goodSize = true;

    // validates the list name so that it only has letters and numbers
    const re = new RegExp('^[A-Za-z0-9 _/-]*[A-Za-z0-9/-][A-Za-z0-9 _/-]*$');
    if (newListName.match(re) && unique && goodSize) {

      // gets the current date and time
      const todayUTC = new Date().getTime();

      // offsets it with 6 hours from zulu time
      const overlap = -6 * 60 * 60000;
      const todayCST = new Date(todayUTC + overlap);

      // creates json object representing new list object
      const newList = { listName: newListName, date: todayCST, items: null, accountId: this.dataService.selectedUserId };

      // sends put http request to service
      await this.userMenuService.addGList(newList).toPromise().then(result => {

        // once result has been achieved, notify user that list was created
        alert("New Grocery List '" + newListName + "' was created!");

        // navigate back to the user menu
        this.router.navigateByUrl('/user-menu');
      });
    }
    else {
      let alertString = "";

      if (!unique) {
        // alerts the user if the list name has already been used
        alertString += "This list name has already been used! Choose a different list name!\n";
      }
      if (!newListName.match(re)) {
        // if the list name is rejected, notify user and have user retype in input box
        alertString += "This is an invalid name for a list. List names can only have '/', '-', '_', ' ', numbers, and letters!\n";
      }
      if (!goodSize) {
        // notify user that the name of list is too long
        alertString += "The name of the list is too long! Needs to be less than or equal to 25 characters long!";
      }
      alert(alertString);
      (document.getElementById('new-list-name') as HTMLInputElement).select();
    }
  }
}
