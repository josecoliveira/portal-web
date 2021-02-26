import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '@environments/environment';
import { User } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  login(email: string, password: string) {
    const httpOptions = {
      headers: new HttpHeaders({
        "Access-Control-Allow-Headers": "*",
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Methods": "GET, PUT, POST, DELETE, HEAD, OPTIONS"
      })
    };
    const userData: User = new User();
    userData.email = email;
    userData.password = password;
    return this.http.post<User>(`${environment.apiUrl}/user/login`, userData, httpOptions)
      .pipe(map(user => {
        console.log("test");
        console.log(user);
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        localStorage.setItem('currentUser', JSON.stringify(user));
        this.currentUserSubject.next(user);
        return user;
      }));
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
}
