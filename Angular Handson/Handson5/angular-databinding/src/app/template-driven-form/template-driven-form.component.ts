import { Component, OnInit } from '@angular/core';
import { AddressModel } from 'src/app/address-model';  

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
    postcode: 0,  
    country: [],  
    aggrement: false  
  };  
  
  constructor() { }  
  
  ngOnInit() {  
  }  
  
  onFormSubmit() {  
    console.log("Full Address", this.model);    
  }  


}
