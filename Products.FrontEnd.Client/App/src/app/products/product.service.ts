import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import {catchError} from 'rxjs/operators'
import { IProductsResponse, IProductResponse } from './models/product-response';
import { UpdateProductRequest, DeleteProductRequest } from './models/product-request';
import { IBaseResponse } from '../shared/base-response';

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
    return this.httpClient.patch<IProductResponse>(this.baseUrl + 'edit', request);
  }

  delete(request: DeleteProductRequest){
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      body: {
        id: request.id
      }
    }
    return this.httpClient.delete<IBaseResponse>(this.baseUrl + 'delete', options);
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
