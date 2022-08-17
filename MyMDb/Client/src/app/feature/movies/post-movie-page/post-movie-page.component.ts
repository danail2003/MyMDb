import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MoviesService } from 'src/app/core/services/movies.service';

@Component({
  selector: 'app-post-movie-page',
  templateUrl: './post-movie-page.component.html',
  styleUrls: ['./post-movie-page.component.css']
})
export class PostMoviePageComponent implements OnInit {
  constructor(private formBuilder: FormBuilder, private moviesService: MoviesService, private router: Router) { }

  postFormGroup: FormGroup = this.formBuilder.group({
    'name': new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
    'country': new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
    'description': new FormControl('', [Validators.required, Validators.minLength(10)]),
    'releaseDate': new FormControl('', [Validators.pattern(/^(1[012]|0[1-9])([\/\-])(0[1-9]|[12]\d|3[01])\2((?:19|20)?\d{2})$/g)]),
    'year': new FormControl('', [Validators.required, Validators.min(1888), Validators.max(2023)]),
    'duration': new FormControl(''),
    'budget': new FormControl(''),
    'gross': new FormControl(''),
    'rating': new FormControl('', [Validators.required, Validators.min(1), Validators.max(10)]),
    'video': new FormControl('', [Validators.required, Validators.pattern(/^http/g)]),
    'image': new FormControl('', [Validators.required, Validators.pattern(/^http/g)])
  });

  ngOnInit(): void {
  }

  createMovie(): void {
    this.moviesService.createMovie(this.postFormGroup.value).subscribe(() => {
      this.router.navigate(['/home']);
    })
  }
}
