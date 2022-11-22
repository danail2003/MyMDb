import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { MoviesService } from 'src/app/core/services/movies.service';
import { createMovie, IMoviesState } from '../state';

@Component({
  selector: 'app-post-movie-page',
  templateUrl: './post-movie-page.component.html',
  styleUrls: ['./post-movie-page.component.css']
})
export class PostMoviePageComponent implements OnInit {
  constructor(private formBuilder: FormBuilder, private moviesService: MoviesService, private router: Router, private store: Store<IMoviesState>) { }

  postFormGroup: FormGroup = this.formBuilder.group({
    'name': new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
    'country': new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]),
    'description': new FormControl('', [Validators.required, Validators.minLength(10)]),
    'releaseDate': new FormControl('', [Validators.pattern(/^(1[012]|0[1-9])([\/\-])(0[1-9]|[12]\d|3[01])\2((?:19|20)?\d{2})$/g)]),
    'year': new FormControl('', [Validators.required, Validators.min(1888), Validators.max(2023)]),
    'duration': new FormControl('', [Validators.required, Validators.pattern("^[0-9]+$")]),
    'budget': new FormControl('', [Validators.required, Validators.pattern("^[0-9]+$")]),
    'gross': new FormControl('', [Validators.required, Validators.pattern("^[0-9]+$")]),
    'rating': new FormControl('', [Validators.required, Validators.pattern("^[0-9]+$"), Validators.min(1), Validators.max(10)]),
    'video': new FormControl('', [Validators.required, Validators.pattern("^https?:\/\/(.*)")]),
    'image': new FormControl('', [Validators.required, Validators.pattern("^https?:\/\/(.*)")]),
    'genres': new FormControl('', [Validators.required, Validators.minLength(2)]),
    'actors': new FormControl('', [Validators.required, Validators.minLength(5)])
  });

  ngOnInit(): void {
  }

  createMovie(): void {
    this.store.dispatch(createMovie({ model: this.postFormGroup.value }));
    this.router.navigate(['/home']);
  }
}
