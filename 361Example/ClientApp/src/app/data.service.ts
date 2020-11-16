import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { BehaviorSubject } from 'rxjs';

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
  loginStatus: boolean;
  public loginStatus1 = new BehaviorSubject<boolean>(this.loginStatus);



  get isLoggedIn() {
    return this.loginStatus1.asObservable();
  }

  
}
