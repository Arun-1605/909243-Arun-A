import { Component, OnInit } from '@angular/core';
import {FormGroup,FormControl,FormBuilder, Validators} from '@angular/forms';

@Component({
  selector: 'app-edit-emp-reactive',
  templateUrl: './edit-emp-reactive.component.html',
  styleUrls: ['./edit-emp-reactive.component.css']
})
export class EditEmpReactiveComponent implements OnInit {
  checkoutForm:FormGroup;
  departments:any=['a','b','c']

  constructor(private formBuilder:FormBuilder) {
    /*this.checkoutForm=formBuilder.group({
    name : new FormControl(),
    skill :new FormControl(),
    dept :new FormControl(),
    sal :new FormControl(),
    permanent:new FormControl()
     });*/

     this.checkoutForm=formBuilder.group({
      name : ['',Validators.required,
      Validators.minLength(4),
      Validators.maxLength(20)],
      skill :['',Validators.required],
      dept :['',Validators.required],
      sal :['',Validators.required],
      permanent:['',Validators.required]
       });
   }

  ngOnInit(): void {
  }

  postData(){
    console.log(this.checkoutForm.value);
  }

}
