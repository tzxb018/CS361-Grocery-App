import { Component, Inject, Injectable, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginService } from '../login.service';
import { DataService } from '../data.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

@Injectable({
  providedIn: 'root'
})
export class HomeComponent {

  // holds all the glists for the component
  public allUsers: User[];

  




}

interface User {
  id: number;
  email: string;
  password: string;
}


