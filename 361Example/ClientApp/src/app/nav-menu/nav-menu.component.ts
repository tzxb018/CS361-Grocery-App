import { Component } from '@angular/core';
import { LoginService } from '../login.service';
import { DataService } from '../data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
})

export class NavMenuComponent {
  public currentUser: User;
  public allUsers: User[];

  constructor(private loginService: LoginService, private router: Router, private dataService: DataService) {

  }



  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  signOut() {
    this.dataService.deauthenticate();
    this.router.navigate(['/']);

  }

}

interface User {
  id: number;
  email: string;
  password: string;
}
