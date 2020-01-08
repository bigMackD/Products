import { Injectable } from '@angular/core';
import { IProductsResponse, IProductResponse } from './product-response';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import {catchError} from 'rxjs/operators'
import { UpdateProductRequest } from './product-request';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
    private baseUrl = 'https://localhost:44351/products/';
    constructor(private httpClient : HttpClient) {
    }

  getAll(): Observable<IProductsResponse> {
    return this.httpClient.get<IProductsResponse>(this.baseUrl + 'get').pipe(
      catchError(this.handleError)
    );
  }

  getById(id: number):  Observable<IProductResponse> {
    return this.httpClient.post<IProductResponse>(this.baseUrl + 'get',{id:id})
  }

  update(request: UpdateProductRequest): Observable<IProductResponse>{
    return this.httpClient.patch<IProductResponse>(this.baseUrl + 'update', request);
  }

  private handleError(err: HttpErrorResponse) {
    let errorResponse: IProductsResponse = {
      success: false,
      content: null,
      errors: []
    }
    if (err.error instanceof ErrorEvent) {
      errorResponse.errors.push(`An error occurred: ${err.message}`)
    } else {
      errorResponse.errors.push(`Server returned code: ${err.status}, error message is: ${err.message}`)
    }
    return throwError(errorResponse);
  }

}
