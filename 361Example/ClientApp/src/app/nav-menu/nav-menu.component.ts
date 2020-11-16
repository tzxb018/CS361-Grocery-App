import { Component, Inject, Injectable, Output, EventEmitter, ViewEncapsulation, OnInit, OnDestroy, ɵɵNgOnChangesFeature, OnChanges, SimpleChanges, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginService } from '../login.service';
import { UserMenuService } from '../user-menu.service';
import { DataService } from '../data.service';
import { ItemListService } from '../item-list.service';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {


  constructor(private dataService: DataService) {

    this.selectedUserName = this.dataService.selectedUserName;
    this.dataService.loginStatus = false;
    this.loginStatus = this.dataService.loginStatus;


  }

  public loginStatus1 = new BehaviorSubject<boolean>(this.dataService.loginStatus);

  isLoggedIn() {
    return this.loginStatus1.asObservable();
  }

  @Input() selectedUserName: string;
  loginStatus: boolean;

  
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }


  ngOnInit() {
    this.selectedUserName = this.dataService.selectedUserName;
    if (this.selectedUserName != null) {
      console.log("selected user name", this.dataService.selectedUserName);

      document.getElementById("hello").innerHTML = "Hello, " + this.selectedUserName;
      document.getElementById("logout").innerHTML = "Logout";
    }
  }

  toggleUser() {
    var hello = document.getElementById("hello");
    if (this.dataService.loginStatus == true) {
      hello.innerHTML = "Hello, " + this.selectedUserName;
    }
  }


    
  }
  

  

