import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  // data to hold which user and grocery list is selected
  selectedGListId: number;
  selectedGListName: string;
  selectedUserId: number;
  existingGLists: any;
  existingItems: any;
  selectedUserName: string;

  constructor() {
    /*this.selectedUserId = 1; // will change when login and users are implemented*/

  }
}
