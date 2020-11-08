import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  selectedGListId: number;
  selectedGListName: string;

  constructor() { }
}
