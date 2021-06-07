import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthServiceService } from './Services/auth-service.service';
import { MenuComponent } from './menu/menu.component';
import { CompanyDetailsComponent } from './company-details/company-details.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { CompanyService } from './company.service';
import { CompaniesListComponent} from "./companies-list/companies-list.component";
import { CompanyWatchListComponent } from './company-watch-list/company-watch-list.component';


@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    CompanyDetailsComponent,
    LoginComponent,
    CompaniesListComponent,
    CompanyWatchListComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule
  ],
  providers: [AuthServiceService, CompanyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
