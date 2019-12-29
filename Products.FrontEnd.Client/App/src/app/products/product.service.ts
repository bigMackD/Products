import { Injectable } from '@angular/core';
import { IProductsResponse, IProductResponse } from './product-response';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import {catchError} from 'rxjs/operators'

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

  private handleError(err: HttpErrorResponse) {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorResponse: IProductsResponse = {
      success: false,
      content: null,
      errors: []
    }
    debugger;
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorResponse.errors.push(`An error occurred: ${err.message}`)
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorResponse.errors.push(`Server returned code: ${err.status}, error message is: ${err.message}`)
    }
    //console.error(errorResponse);
    return throwError(errorResponse);
  }

}
