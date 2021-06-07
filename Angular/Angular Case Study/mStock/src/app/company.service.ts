import { Injectable } from '@angular/core';
import { CompanyDetails } from './Types/CompanyDetails';
import { catchError } from 'rxjs/internal/operators';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  url : string= "http://localhost:52682/api/companies";
  flag1 :string="";
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
  check(flag:any){
    this.flag1=flag;
  }
  logoutforCompanyList(){
    this.flag1="false";
    
    }
  get checkcompanyList(){
      return this.flag1;
    }
  getCompanies(): Observable<any> {
    return this.http.get<CompanyDetails[]>(this.url).pipe(
      catchError(this.handleError)
    );
  }
}

