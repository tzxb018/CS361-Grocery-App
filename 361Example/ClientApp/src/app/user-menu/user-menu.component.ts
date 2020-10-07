import { Component } from '@angular/core';

@Component({
  selector: 'user-menu-component',
  templateUrl: './user-menu.component.html'
})
export class UserMenuComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
