import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompaniesListComponent } from './companies-list/companies-list.component';
import { CompanyWatchListComponent } from './company-watch-list/company-watch-list.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
    {path : 'login' , component : LoginComponent},
    {path : 'Companies' , component : CompaniesListComponent},
    {path : 'Watch-list' , component : CompanyWatchListComponent},
    {path : 'Compare-Performance' , component : LoginComponent},
    {path : 'logout' , component : LoginComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
