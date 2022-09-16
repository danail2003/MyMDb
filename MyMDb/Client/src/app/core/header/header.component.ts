import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { getUserSelector, IAuthState, loadUser } from '../state';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  currentUser$: Observable<string> = this.store.select(getUserSelector);

  constructor(private authService: AuthService, private router: Router, private store: Store<IAuthState>) { }

  get isLogged(): boolean {
    return this.authService.isLogged;
  }

  get isAdmin(): boolean {
    return this.authService.isAdmin;
  }

  ngOnInit(): void {
    this.store.dispatch(loadUser());
  }

  handleLogout(): void {
    this.authService.logout();
    this.router.navigate(['/']);
  }
}
