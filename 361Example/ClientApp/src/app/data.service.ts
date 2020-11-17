import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  authenticated$: BehaviorSubject<boolean> = new BehaviorSubject(false);

  // data to hold which user and grocery list is selected
  selectedGListId: number;
  selectedGListName: string;
  selectedUserId: number;
  existingGLists: any;
  existingItems: any;
  selectedUserName: string;

  public authenticate() {
    this.authenticated$.next(true);
  }

  public deauthenticate() {
    this.authenticated$.next(false);
    this.selectedGListId = null;
    this.selectedGListName = null;
    this.selectedUserId = null;
    this.existingGLists = null;
    this.existingItems = null;
    this.selectedUserName = null;
  }
  constructor() {
    //this.selectedUserId = 1; // will change when login and users are implemented

  }
}
