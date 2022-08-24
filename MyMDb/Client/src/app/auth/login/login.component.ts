import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginUserDTO } from 'src/app/core/models/loginUserDto';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(private authService: AuthService, private formBuilder: FormBuilder, private router: Router) { }

  loginFormGroup: FormGroup = this.formBuilder.group({
    'email': new FormControl('', [Validators.required, Validators.email]),
    'password': new FormControl('', [Validators.required, Validators.minLength(6)])
  });

  ngOnInit(): void {
  }

  login(): void {
    const { email, password } = this.loginFormGroup.value;

    const body: LoginUserDTO = {
      email,
      password
    };

    this.authService.login(body).subscribe((token) => {
      document.cookie = `session=${token.result}`;

      this.router.navigate(['/']);
    })
  }
}
