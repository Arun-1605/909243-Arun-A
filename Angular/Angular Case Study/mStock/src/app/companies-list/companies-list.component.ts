import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CompanyDetailsComponent } from '../company-details/company-details.component';
import { CompanyWatchServiceService } from '../company-watch-service.service';
import { AuthServiceService } from '../Services/auth-service.service';

@Component({
  selector: 'app-companies-list',
  templateUrl: './companies-list.component.html',
  styleUrls: ['./companies-list.component.css']
})
export class CompaniesListComponent implements OnInit {

  userLoggedIn : boolean = false;
  subs: Subscription = new Subscription;
  constructor(private acct : AuthServiceService,
    private com : CompanyDetailsComponent,
    private watchlist : CompanyWatchServiceService) { }

ngOnInit(){
  this.subs = this.acct.OnLoggedIn.subscribe(res => this.userLoggedIn = res);
}

ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

// addToWatchHandler(companyCode: number, userId : number) {
//     this.watchlist.AddToWatch(companyCode,userId).subscribe(res => this.watchlist = res);
//   }


}
