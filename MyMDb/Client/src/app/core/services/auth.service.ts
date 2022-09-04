import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CreateUserDTO } from '../models/createUserDTO';
import { LoginUserDTO } from '../models/loginUserDto';

@Injectable()
export class AuthService {
  isLogged: boolean = false;

  constructor(private httpClient: HttpClient) { }

  register(user: CreateUserDTO): Observable<string> {
    return this.httpClient.post<string>(`${environment.apiUrl}/auth/register`, user);
  }

  login(user: LoginUserDTO): Observable<any> {
    return this.httpClient.post<any>(`${environment.apiUrl}/auth/login`, user).pipe(tap(() => {
      this.isLogged = true;
    }));
  }

  logout(): void {
    this.isLogged = false;
    document.cookie = 'session=;expires=Thu, 01 Jan 1970 00:00:01 GMT';
  }

  authenticate(): boolean {
    const token = document.cookie;

    if (!token) {
      return this.isLogged = false;
    }

    return this.isLogged = true;
  }

  get isAdmin(): boolean {
    const token = document.cookie;

    if (!token) {
      return false;
    }

    const helper = new JwtHelperService();
    let decodedToken = helper.decodeToken(token);
    
    if (decodedToken[Object.keys(decodedToken)[1]] == 'Admin') {
      return true;
    }

    return false;
  }
}
