import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { ICellRendererParams } from 'ag-grid-community';
import { RemoveFromWatchlistDTO } from 'src/app/core/models/removeFromWatchlistDTO';
import { AuthService } from 'src/app/core/services/auth.service';
import { MoviesService } from 'src/app/core/services/movies.service';
import { IMoviesState, removeFromWatchlist } from '../../../state';

@Component({
  selector: 'btn-cell-renderer',
  template: `
    <button (click)="btnClickedHandler()">Remove from watchlist</button>
  `,
})
export class BtnCellRendererComponent implements ICellRendererAngularComp {
  constructor(private authService: AuthService, private movieService: MoviesService, private store: Store<IMoviesState>) {

  }
  refresh(params: ICellRendererParams<any, any>): boolean {
    throw new Error('Method not implemented.');
  }
  private params: any;

  agInit(params: any): void {
    this.params = params;
  }

  btnClickedHandler() {
    this.params.clicked(this.params.value);
    const body: RemoveFromWatchlistDTO = { email: this.authService.getEmail, movieId: this.params.value };
    this.store.dispatch(removeFromWatchlist({ userMovie: body }));
  }
}
