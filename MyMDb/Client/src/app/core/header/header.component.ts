import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  currentUser: Observable<string> = this.authService.currentUser;

  constructor(private authService: AuthService, private router: Router) { }

  get isLogged(): boolean {
    return this.authService.isLogged;
  }

  get isAdmin(): boolean {
    return this.authService.isAdmin;
  }

  ngOnInit(): void {
    console.log(this.currentUser);
    
  }

  handleLogout(): void {
    this.authService.logout();
    this.router.navigate(['/']);
  }
}
