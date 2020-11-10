import { Component, OnInit } from '@angular/core';
import { ItemListService } from '../item-list.service';
import { DataService } from '../data.service';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent {

  constructor(private itemListService: ItemListService, private dataService: DataService) {
  }

  async addItem() {

    const newItemName = (document.getElementById('new-item-name') as HTMLInputElement).value;
    const newItemNum = Number((document.getElementById('new-item-num') as HTMLInputElement).value);
    const gListID = this.dataService.selectedGListId;
    let todayUTC = new Date().getTime();
    let overlap = -6 * 60 * 60000;
    let todayCST = new Date(todayUTC + overlap);
    const newItem = { name: newItemName, date: todayCST, checkoff: false, quantity: newItemNum, groceryListId: gListID };

    await this.itemListService.addItem(newItem).toPromise().then();
  }

}

interface Item {
  id: number;
  name: string;
  date: Date;
  checkoff: boolean;
  quantity: number;
  groceryListId: number;
}
