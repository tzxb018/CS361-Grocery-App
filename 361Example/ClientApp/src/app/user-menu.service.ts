import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserMenuService {

  private headers: HttpHeaders;

  // public list to hold all the glist instances
  public gLists: GList[];

  const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: 'my-auth-token'
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
  public getAllGLists() {

    // this will only populate the glists if there are no errors
    return this.http.get<GList[]>(this.baseUrl + 'glist')
      .pipe(
        retry(3),
        catchError(this.handleError)
      );
  }

  public get() {
    return this.http.get(this.baseUrl, { headers: this.headers });
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

  public update(payload) {
    return this.http.put(this.baseUrl + '/' + payload.id, payload, { headers: this.headers });
  }
}
interface GList {
  id: number;
  listName: string;
  date: Date;
  items: any;
  accountId: number;
}
