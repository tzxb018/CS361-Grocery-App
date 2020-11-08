import { Component, Inject, Input, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserMenuService } from '../user-menu.service';
import { UserMenuComponent } from '../user-menu/user-menu.component';

@Component({
  selector: 'app-new-list',
  templateUrl: './new-list.component.html',
  styleUrls: ['./new-list.component.css'],

})
export class NewListComponent {

  constructor(private userMenuService: UserMenuService, private userMenuComponent: UserMenuComponent) { }

  async addGList() {

    const newListName = (document.getElementById('new-list-name') as HTMLInputElement).value;
    let todayUTC = new Date().getTime();
    let overlap = -6 * 60 * 60000;
    let todayCST = new Date(todayUTC + overlap);
    const newList = { listName: newListName, date: todayCST, items: null, accountId: 1 };

    await this.userMenuService.addGList(newList).toPromise().then();

    await this.userMenuComponent.refreshTable();
  }


}
