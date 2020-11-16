import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

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

  isLoggedIn() {
    return this.loginStatus
  }

  
}
