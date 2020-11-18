import { Component, Inject, Injectable, Output, EventEmitter, ViewEncapsulation, OnInit, OnDestroy, } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginService } from '../login.service';
import { DataService } from '../data.service';
import { Router, Data } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./bg.component.scss'],
  encapsulation: ViewEncapsulation.None,
})

@Injectable({
  providedIn: 'root'
})


export class HomeComponent {

  ngOnInit() {
    document.body.classList.add('bg');
    this.dataService.loginStatus = false;
    // OR you can Add inline style css with the help of code below
    // this._document.body.style.background = '#fff';



  }
  ngOnDestroy() {
    // remove the class form body tag
    document.body.classList.remove('bg');
  }

  // holds all the glists for the component
  public allUsers: User[];
  public login: number;
  public currentUser: User;



  constructor(private loginService: LoginService, private router: Router, private dataService: DataService) {

    this.refreshTable();
    console.log("login status", this.dataService.loginStatus);
    var iframes = document.querySelectorAll('iframe');
    for (var i = 0; i < iframes.length; i++) {
      iframes[i].parentNode.removeChild(iframes[i]);
    }
  }

  //func to refresh table
  async refreshTable() {

    const result = await this.loginService.getAllUser().toPromise();
    this.allUsers = result;

  }


  verifyUser() {
    const emailForm = document.getElementById("email") as HTMLInputElement;
    const email = emailForm.value;
    const passwordForm = document.getElementById("password") as HTMLInputElement;
    const password = passwordForm.value;

    if (email.length > 0) {
      for (const user of this.allUsers) {
        if (email == user.email && password == user.password) {
          this.login = 1;
          this.router.navigate(['/user-menu']);
          this.currentUser = user;
          this.dataService.selectedUserId = user.id;
          this.dataService.selectedUserName = user.email;

          this.dataService.authenticate();

          break;
        } else {
          this.login = 0;
          document.getElementById("feedback").innerHTML = "Incorrect email or password, please try again.";
        }
      }
    }

  }

}

interface User {
  id: number;
  email: string;
  password: string;
}
