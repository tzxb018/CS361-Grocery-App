import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';


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
  loginStatus: boolean;
  public loginStatus1 = new BehaviorSubject<boolean>(this.loginStatus);


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
 


  
}
