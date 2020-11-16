import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { throwError, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private headers: HttpHeaders;

  // public list to hold all the glist instances
  public users: User[];

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

  public getAllUser() {

    // this will only populate the user if there are no errors
    return this.http.get<User[]>(this.baseUrl + 'user')
      .pipe(
        retry(3),
        catchError(this.handleError)
      );
  }

  public insertUser(user): Observable<User> {
    return this.http.post<User>(this.baseUrl + 'user', user, this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  public update(payload) {
    return this.http.put(this.baseUrl + '/' + payload.id, payload, { headers: this.headers });
  }
}
interface User {
  id: number;
  email: string;
  password: string;
}
