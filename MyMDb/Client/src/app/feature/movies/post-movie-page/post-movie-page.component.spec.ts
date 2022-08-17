import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostMoviePageComponent } from './post-movie-page.component';

describe('PostMoviePageComponent', () => {
  let component: PostMoviePageComponent;
  let fixture: ComponentFixture<PostMoviePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostMoviePageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PostMoviePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
