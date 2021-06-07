import { Injectable } from '@angular/core';
import {BehaviorSubject, Subject, throwError} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {catchError, map, retry} from 'rxjs/operators';
import { CompanyService } from '../company.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {
  url : string = "http://localhost:52682/api/auth";
  private isLoggedIn = new BehaviorSubject<boolean> (false);
  private CallMethodSource  = new Subject<any>();
  CallMethodSource$ = this.CallMethodSource.asObservable();
  SetAuthenticated() {
    this.CallMethodSource.next();
  }
  OnLoggedIn = this.isLoggedIn.asObservable();
  flag: any;
  constructor(private http : HttpClient, 
    private router: Router,private com: CompanyService) { }
   isAuthenticated(status : boolean) {
     this.isLoggedIn.next(status);
   }

  Validate(userDetails: any) {
    return this.http.post(this.url, userDetails).pipe(map((response) => {
      this.flag=response;
      console.log(this.flag)
this.com.check(JSON.stringify(this.flag));

        return response;
     }
     ),
      retry(1),
      catchError(this.handleError)
    )
  }
  get logout() {
    return this.http.get(this.url + '/logout')
        .pipe(map((response) => {
        
          return response}))
        
}


handleError(error:any) {
  let errorMessage = '';
  if(error.error instanceof ErrorEvent) {
    
    errorMessage = error.error.message;
  } else {
 
    errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
  }
  window.alert(errorMessage);
  return throwError(errorMessage);
}


}
