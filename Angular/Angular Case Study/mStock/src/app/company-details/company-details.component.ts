import { Component, OnInit, Input, Output, Injectable } from '@angular/core';
import { CompanyDetails } from '../Types/CompanyDetails';
import {CompanyService} from '../company.service';
import { EventEmitter} from '@angular/core';
import { AuthServiceService } from '../Services/auth-service.service';
import { Subscription } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
@Component({
  selector: 'app-company-details',
  templateUrl: './company-details.component.html',
  styleUrls: ['./company-details.component.css']
})
export class CompanyDetailsComponent implements OnInit {
  com: CompanyDetails[] = [];
  ShowWatchButton : boolean = false;
  subs: Subscription = new Subscription;
  constructor(private cs : CompanyService,
    private aser : AuthServiceService) { }

  ngOnInit(): void {
    this.subs = this.aser.OnLoggedIn.subscribe(res => this.ShowWatchButton = res);
    this.cs.getCompanies().subscribe((data: CompanyDetails[]) => this.com = data);
  }

  @Output() onAddToWatch = new EventEmitter<any>();
  AddToWatchHandler(companycode: any ) {
    this.onAddToWatch.emit(companycode);
  }

}
