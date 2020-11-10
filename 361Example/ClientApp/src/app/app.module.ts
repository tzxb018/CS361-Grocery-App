import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { NewAccountComponent } from './new-account/new-account.component';
import { ItemListComponent } from './item-list/item-list.component';
import { UserMenuComponent } from './user-menu/user-menu.component';
import { FaqComponent } from './faq/faq.component';
import { NewListComponent } from './new-list/new-list.component';

import { AddItemComponent } from './add-item/add-item.component';
import { UserMenuService } from './user-menu.service';
import { ItemListService } from './item-list.service';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: '/user-menu', component: UserMenuComponent },
  { path: '/item-list', component: ItemListComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    NewAccountComponent,
    ItemListComponent,
    FaqComponent,
    UserMenuComponent,
    NewListComponent,
    AddItemComponent,


  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'new-account', component: NewAccountComponent },
      { path: 'item-list', component: ItemListComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'faq', component: FaqComponent },
      { path: 'user-menu', component: UserMenuComponent },
      { path: 'new-list', component: NewListComponent },
      { path: 'add-item', component: AddItemComponent },
    ])
  ],
  providers: [
    UserMenuComponent,
    UserMenuService,
    ItemListComponent,
    ItemListService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
