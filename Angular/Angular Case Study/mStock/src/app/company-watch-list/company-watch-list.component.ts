import { Component, OnInit } from '@angular/core';
import { CompanyDetailsComponent } from '../company-details/company-details.component';
import { CompanyWatchServiceService } from '../company-watch-service.service';

@Component({
  selector: 'app-company-watch-list',
  templateUrl: './company-watch-list.component.html',
  styleUrls: ['./company-watch-list.component.css']
})
export class CompanyWatchListComponent implements OnInit {

  constructor(private watchlist : CompanyWatchServiceService,
    private com : CompanyDetailsComponent) { }

  ngOnInit(): void {
  }
  AddToWatchHandler(companycode: any ) {
    this.com.onAddToWatch.emit(companycode);
  }
  

}
