import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserMenuService {

  private headers: HttpHeaders;
  //private accessPointUrl: string = 'http://localhost:44312/api/glists';

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public get() {
    return this.http.get(this.baseUrl, { headers: this.headers });
  }

  public add(payload) {
    return this.http.post(this.baseUrl, payload, { headers: this.headers });
  }

  public remove(payload) {
    return this.http.delete(this.baseUrl + '/' + payload.id, { headers: this.headers });
  }

  public update(payload) {
    return this.http.put(this.baseUrl + '/' + payload.id, payload, { headers: this.headers });
  }


}
