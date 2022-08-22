import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CreateUserDTO } from 'src/app/core/models/createUserDTO';
import { User } from 'src/app/core/models/user';
import { AuthService } from 'src/app/core/services/auth.service';
import { passwordMatch } from '../utils';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  constructor(private authService: AuthService, private router: Router, private formBuilder: FormBuilder) { }

  passwordFormControl = new FormControl('', [Validators.required, Validators.minLength(6)])

  registerFormGroup: FormGroup = this.formBuilder.group({
    'email': new FormControl('', [Validators.required, Validators.email]),
    'password': this.passwordFormControl,
    'rePassword': new FormControl('', [Validators.required, passwordMatch(this.passwordFormControl)])
  });

  ngOnInit(): void {
  }

  register(): void {
    const { email, password, rePassword } = this.registerFormGroup.value;

    const body: CreateUserDTO = {
      email,
      password,
      repeatPassword: rePassword
    };

    this.authService.register(body).subscribe(() => {
      this.router.navigate(['/auth/login']);
    })
  }
}
