import { Component, Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subscription} from 'rxjs';
import { AuthServiceService } from '../Services/auth-service.service';
@Injectable({ 
  providedIn: 'root'
 })

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit{
  // subs: Subscription = new Subscription;
  // userLoggedIn : Boolean | undefined;
  // constructor(private as : AuthServiceService) { 
  // }
  // ngOnInit(): void {
  //   this.subs = this.as.OnLoggedIn.subscribe(res => this.userLoggedIn = res);
  // }
  // ngOnDestroy(): void {
  //   this.subs.unsubscribe();
  // }
  title = 'mStock';
  userLoggedIn : boolean = false;
  subs: Subscription = new Subscription;
 flag1:string="";

  constructor(
  private acct:AuthServiceService,
  private router: Router
  ){}
ngOnInit(){
  this.router.navigate([''])
  this.subs = this.acct.OnLoggedIn.subscribe(res => this.userLoggedIn = res);
}
logoutCheck(){
  this.flag1="false";
}

checkStatus(flag:any){
this.flag1= flag;
//console.log(this.flag1);
}
ngOnDestroy(): void {
    this.subs.unsubscribe();
   }

}
  

