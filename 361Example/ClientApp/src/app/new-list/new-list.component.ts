import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserMenuService } from '../user-menu.service';

@Component({
  selector: 'app-new-list',
  templateUrl: './new-list.component.html',
  styleUrls: ['./new-list.component.css'],

})
export class NewListComponent {

  constructor(private userMenuService: UserMenuService, private router: Router) { }

  async addGList() {

    const newListName = (document.getElementById('new-list-name') as HTMLInputElement).value;
    let todayUTC = new Date().getTime();
    let overlap = -6 * 60 * 60000;
    let todayCST = new Date(todayUTC + overlap);
    const newList = { listName: newListName, date: todayCST, items: null, accountId: 1 };

    await this.userMenuService.addGList(newList).toPromise().then(result => {
      alert("New Grocery List '" + newListName + "' was created!");
      this.router.navigateByUrl('/user-menu');
    }
    );


  }


}
