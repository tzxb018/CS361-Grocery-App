import { Component, Inject, Injectable, Output, EventEmitter, ViewEncapsulation, OnInit, OnDestroy, ɵɵNgOnChangesFeature, OnChanges, SimpleChanges, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginService } from '../login.service';
import { UserMenuService } from '../user-menu.service';
import { DataService } from '../data.service';
import { ItemListService } from '../item-list.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  @Input() selectedUserName: string;
  loginStatus: boolean;

  
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  constructor(private dataService: DataService) {

    this.selectedUserName = this.dataService.selectedUserName;
    this.loginStatus = this.dataService.loginStatus;
    this.loginStatus = true;
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
  

  

