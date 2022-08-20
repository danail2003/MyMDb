import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CreateUserDTO } from '../models/createUserDTO';
import { User } from '../models/user';

@Injectable()
export class AuthService {

  constructor(private httpClient: HttpClient) { }

  register(user: CreateUserDTO): Observable<string> {
    return this.httpClient.post<string>(`${environment.apiUrl}/auth/regiser`, user);
  }

  login(user: User): Observable<string> {
    return this.httpClient.post<string>(`${environment.apiUrl}/auth/login`, user);
  }
}
