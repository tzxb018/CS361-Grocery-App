import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserMenuService {

  private headers: HttpHeaders;

  // public list to hold all the glist instances
  public gLists: GList[];

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

  // gets all the glists and populates the tables
  public getGListsForUser(accountID: number) {

    // this will only populate the glists if there are no errors
    return this.http.get<GList[]>(this.baseUrl + 'glist' + `\\user${accountID}`)
      .pipe(
        retry(3),
        catchError(this.handleError)
      );
  }

  public getSpecificGList(id: number) {
    return this.http.get<GList>(this.baseUrl + 'glist' + `\\${id}`, { headers: this.headers });
  }

  addGList(newList) {

    return this.http.post<GList>(this.baseUrl + 'glist', newList, this.httpOptions).pipe(
      retry(3),
      catchError(this.handleError)
    );
  }

  // function to delete the glist from the table
  deleteGList(id: number) {

    // gets the url of the deleted glist with the ID (defined in the GListController headers)
    const url = this.baseUrl + `glist\\${id}`;

    // deletes the glist only if there is no errors
    return this.http.delete(url).pipe(
      catchError(this.handleError)
    );
  }

  public updateGList(payload, id: number) {

    const url = this.baseUrl + 'glist' + `\\${id}`;
    console.log("updated", url);
    console.log("updated glist", payload);
    return this.http.put<GList>(url, payload, this.httpOptions).pipe(
      retry(3),
      catchError(this.handleError)
    );
  }
}
interface GList {
  id: number;
  listName: string;
  date: Date;
  items: any;
  accountId: number;
}
