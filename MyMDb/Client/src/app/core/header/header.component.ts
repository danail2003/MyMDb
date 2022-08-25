import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  currentUser!: any;

  constructor(private authService: AuthService, private router: Router) { }

  get isLogged(): boolean {
    return this.authService.isLogged;
  }

  ngOnInit(): void {
    const token = document.cookie;

    if (!token) {
      return;
    }

    const helper = new JwtHelperService();

    let decodedToken = helper.decodeToken(token);
    decodedToken = decodedToken[Object.keys(decodedToken)[0]];

    this.currentUser = decodedToken;
  }

  handleLogout(): void {
    this.authService.logout();
    this.router.navigate(['/']);
  }
}
