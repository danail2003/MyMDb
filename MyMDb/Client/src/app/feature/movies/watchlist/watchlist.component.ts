import { Component, OnInit } from '@angular/core';
import { ColDef, GridOptions } from 'ag-grid-community';
import { Observable } from 'rxjs';
import { Movie } from 'src/app/core/models/movie';
import { RemoveFromWatchlistDTO } from 'src/app/core/models/removeFromWatchlistDTO';
import { AuthService } from 'src/app/core/services/auth.service';
import { MoviesService } from 'src/app/core/services/movies.service';
import { BtnCellRendererComponent } from './components/btn-cell-renderer/btn-cell-renderer.component';

@Component({
  selector: 'app-watchlist',
  templateUrl: './watchlist.component.html',
  styleUrls: ['./watchlist.component.css']
})
export class WatchlistComponent implements OnInit {
  public options: GridOptions
  public movies$: Observable<Movie[]>;
  public movies: Movie[];
  private email: string;

  constructor(public movieService: MoviesService, public authService: AuthService) { }

  ngOnInit(): void {
    this.initGrid();
    this.email = this.authService.getEmail;
    this.movies$ = this.movieService.myWatchlist({ email: this.email })
    this.movies$.subscribe(movies => this.movies = movies);
  }

  private initGrid(): void {
    this.options = <GridOptions>{
      headerHeight: 40,
      rowHeight: 40,
      suppressTouch: true,
      suppressClickEdit: true,
      suppressMovableColumns: true,
      suppressMenuHide: true,
      animateRows: true,
      debounceVerticalScrollbar: true,
      enableRangeSelection: true,
      immutableData: true,

      defaultColDef: <ColDef>{
        resizable: true
      }
    }
  }

  columnDefs: ColDef[] = [
    {
      field: 'image',
      headerName: '',
      cellRenderer: (params: any) => `<img style="height: 40px; width: 40px" src=${params.data.image} />`
    },
    { field: 'name' },
    { field: 'year' },
    { field: 'description' },
    { field: 'duration' },
    { field: 'rating' },
    {
      field: 'id',
      headerName: '',
      width: 334,
      cellRenderer: BtnCellRendererComponent,
      cellRendererParams: {
        clicked: function (field: any) {
          
          
        }
      }
    }
  ];
}
