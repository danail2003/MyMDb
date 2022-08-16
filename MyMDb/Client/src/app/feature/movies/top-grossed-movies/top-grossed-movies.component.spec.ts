import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopGrossedMoviesComponent } from './top-grossed-movies.component';

describe('TopGrossedMoviesComponent', () => {
  let component: TopGrossedMoviesComponent;
  let fixture: ComponentFixture<TopGrossedMoviesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TopGrossedMoviesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TopGrossedMoviesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
