import { Component, OnInit, NgModule } from '@angular/core';
import { FormBuilder, FormsModule, FormControl, FormGroup, Validators , ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { MenuComponent } from '../menu/menu.component';
import { AuthServiceService } from '../Services/auth-service.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  // email : any;
  // password : any;
  submitted : boolean =  false;
  signinForm= new FormGroup({});
  flag: any;
  constructor(private aser : AuthServiceService, 
    private router: Router,
    private menu : MenuComponent,
    public formBuilder:FormBuilder) { 
  }
  ngOnInit(): void {
    this.signinForm=this.formBuilder.group({
      email: ['', [Validators.compose([Validators.required, Validators.pattern('^[^\\s@]+@[^\\s@]+\\.[^\\s@]{2,}$'), Validators.minLength(1)])]],
      password: ['', [Validators.required, Validators.minLength(4)]],
      
       });
  }
  get f() { return this.signinForm.controls; }
 Login() 
 {
  this.submitted = true;
  const userDetails = {
   email:this.signinForm.get("email")?.value,
    password: this.signinForm.get('password')?.value
  }
  this.aser.Validate(userDetails)
      .subscribe(
        (res:any) => {
          if(res) {
            this.aser.isAuthenticated(true);
            //console.log('res: ', res);
            this.flag=res;
                  //console.log(this.flag);
                  //this.flag = true;
                 this.check();
            this.router.navigate(['/Companies']);  
          }
        },
        (err:any) => {
          this.aser.isAuthenticated(false);
          alert('Invalid username/password');
        }
      );
    this.signinForm.reset();
  }

  check(){
    //console.log(this.flag);
this.menu.checkStatus(this.flag);
  }
}