import { Component, OnInit } from '@angular/core';
import { ColDef, GridOptions } from 'ag-grid-community';

@Component({
  selector: 'app-watchlist',
  templateUrl: './watchlist.component.html',
  styleUrls: ['./watchlist.component.css']
})
export class WatchlistComponent implements OnInit {
  public options: GridOptions
  constructor() { }

  ngOnInit(): void {
    this.initGrid();
  }

  private initGrid(): void {
    this.options = <GridOptions>{
      headerHeight: 40,
      rowHeight: 40,
      suppressTouch: true,
      suppressClickEdit: true,
      suppressMovableColumns: true,
      suppressMenuHide: true,
      animateRows: false,
      debounceVerticalScrollbar: true,
      enableRangeSelection: true,
      immutableData: true,

      defaultColDef: <ColDef>{
        resizable: true
      }
    }
  }

  columnDefs: ColDef[] = [
    { field: 'make' },
    { field: 'model' },
    { field: 'price' }
  ];

  rowData = [
    { make: 'Toyota', model: 'Celica', price: 35000 },
    { make: 'Ford', model: 'Mondeo', price: 32000 },
    { make: 'Porsche', model: 'Boxster', price: 72000 }
  ];
}
