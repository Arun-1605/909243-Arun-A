import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { PerformanceComponent } from './performance/performance.component';

import { LoginComponent } from './login/login.component';
import { WatchListComponent } from './watch-list/watch-list.component';
import { CompanyDetailsComponent } from './company-details/company-details.component';
import {HttpClientModule} from '@angular/common/http';
import { CompaniesListComponent } from './companies-list/companies-list.component';


@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    PerformanceComponent,

    LoginComponent,
    WatchListComponent,
    CompanyDetailsComponent,
    CompaniesListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [MenuComponent]
})
export class AppModule { }
