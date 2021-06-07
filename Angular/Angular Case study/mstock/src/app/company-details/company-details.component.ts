import { Component, OnInit } from '@angular/core';
import {CompanyDetails } from '../Types/CompanyDetails';
import {CompanyWatchService} from '../Services/company-watch-service.service';
@Component({
  selector: 'app-company-details',
  templateUrl: './company-details.component.html',
  styleUrls: ['./company-details.component.css']
})
export class CompanyDetailsComponent implements OnInit {
  items = this.companywatchservice.getWatchList();
  constructor(
    private companywatchservice : CompanyWatchService
  ) { }

  ngOnInit(): void {
  }

  removecart(item:any,key:any){
this.companywatchservice.removeFromWatchList(item,key);
  }

}