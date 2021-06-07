import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { analyzeAndValidateNgModules } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CompanyWatchServiceService {
  url : string= "http://localhost:52682/api/WatchList";
  constructor(private http: HttpClient) {}
  private handleError(error: HttpErrorResponse): any {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    return throwError(
      'Something bad happened; please try again later.');
  }
  AddToWatch(companyCode : number, userId : number): Observable<any> {
    const watchdetails: any[] = [companyCode,userId];
    return this.http.post(this.url,watchdetails).pipe(
      catchError(this.handleError)
    );
  }
}

