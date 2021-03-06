import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProduct } from './models/product';
import { IPagination } from './models/Pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  products: IPagination[] = [];
  constructor(private http: HttpClient) {
  }
  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/Products/GetProducts').subscribe((response: IPagination[]) => {
      this.products = response.data;
    }, error => {
      console.log(error);
    });
  }
}
