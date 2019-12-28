import { Injectable } from '@angular/core';

import { IProduct, IProductResponse } from './product-response';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
    private productUrl = 'https://localhost:44351/products/get';

    constructor(private httpClient : HttpClient) {

    }

  getProducts(): Observable<IProductResponse> {
  return this.httpClient.get<IProductResponse>(this.productUrl);
  }
}
