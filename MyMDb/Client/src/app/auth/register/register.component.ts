import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { CreateUserDTO } from 'src/app/core/models/createUserDTO';
import { User } from 'src/app/core/models/user';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  constructor(private authService: AuthService, private router: Router, private formBuilder: FormBuilder) { }

  registerFormGroup: FormGroup = this.formBuilder.group({

  });

  ngOnInit(): void {
  }

  register(): void {
    const { email, password, rePassword } = this.registerFormGroup.value;
    console.log(email, password, rePassword);

    const body: CreateUserDTO = {
      email,
      password,
    };

    this.authService.register(body).subscribe(() => {
      this.router.navigate(['/login']);
    })
  }
}
