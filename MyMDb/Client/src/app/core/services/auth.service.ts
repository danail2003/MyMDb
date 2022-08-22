import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CreateUserDTO } from '../models/createUserDTO';
import { LoginUserDTO } from '../models/loginUserDto';

@Injectable()
export class AuthService {

  constructor(private httpClient: HttpClient) { }

  register(user: CreateUserDTO): Observable<string> {
    return this.httpClient.post<string>(`${environment.apiUrl}/auth/register`, user);
  }

  login(user: LoginUserDTO): Observable<any> {
    return this.httpClient.post<any>(`${environment.apiUrl}/auth/login`, user);
  }
}
