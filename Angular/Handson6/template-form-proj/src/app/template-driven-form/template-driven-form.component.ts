import { Component, OnInit } from '@angular/core';
import { AddressModel } from 'src/app/address-model';  
import { FormControl, FormGroup } from '@angular/forms'

@Component({
  selector: 'app-template-driven-form',
  templateUrl: './template-driven-form.component.html',
  styleUrls: ['./template-driven-form.component.css']
})
export class TemplateDrivenFormComponent implements OnInit {

  countryData: any[] = ['India', 'US', 'UK'];  
  
  model: AddressModel = {  
    address: '',  
    city: '',  
    state:'',  
    postcode: '',  
    country: [],  
    aggrement: false  
  };  
  
  address:any;
  userForm:any;
  constructor() { }  
  
  ngOnInit() {  
    this.userForm = new FormGroup({
      address: new FormControl("dfgh"),
    
  }); 
  }  
  
  onFormSubmit() {  
    console.log("Full Address", this.model);    
  }  

 
}
