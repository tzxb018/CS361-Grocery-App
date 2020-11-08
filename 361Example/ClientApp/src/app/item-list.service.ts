import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ItemListService {
  private headers: HttpHeaders;

  // public list to hold all the item instances
  public Items: Item[];

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // Return an observable with a user-facing error message.
    return throwError(
      'Something bad happened; please try again later.');
  }

  // gets all the items and populates the tables
  public getAllItems() {

    // this will only populate the items if there are no errors
    return this.http.get<Item[]>(this.baseUrl + 'item')
      .pipe(
        retry(3),
        catchError(this.handleError)
      );
  }

  public get() {
    return this.http.get(this.baseUrl, { headers: this.headers });
  }

  addItem(newList) {

    return this.http.post<Item>(this.baseUrl + 'item', newList, this.httpOptions).pipe(
      retry(3),
      catchError(this.handleError)
    );
  }

  // function to delete the item from the table
  deleteItem(id: number) {

    // gets the url of the deleted item with the ID (defined in the ItemController headers)
    const url = this.baseUrl + `item\\${id}`;

    // deletes the item only if there is no errors
    return this.http.delete(url).pipe(
      catchError(this.handleError)
    );
  }

  public update(payload) {
    return this.http.put(this.baseUrl + '/' + payload.id, payload, { headers: this.headers });
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
