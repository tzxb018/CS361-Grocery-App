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

    // validates the list name so that it only has letters and numbers
    const re = new RegExp('^[A-Za-z0-9 _/-]*[A-Za-z0-9/-][A-Za-z0-9 _/-]*$');
    if (newListName.match(re) && unique) {

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
    else if (!unique) {
      // alerts the user if the list name has already been used
      alert("This list name has already been used! Chooose a different list name");
      (document.getElementById('new-list-name') as HTMLInputElement).select();

    }
    else {
      // if the list name is rejected, notify user and have user retype in input box
      alert("This is an invalid name for a list. List names can only have '/', '-', '_', ' ', numbers, and letters!");
      (document.getElementById('new-list-name') as HTMLInputElement).select();
    }
  }
}
