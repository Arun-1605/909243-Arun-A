import { Component, OnDestroy, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { Subscription } from 'rxjs';
@Component({
  selector: 'app-child',
  template : `
  <h2> Child Component : {{message}} </h2>
  `,
  styleUrls: ['./child.component.css']
})
export class ChildComponent implements OnInit ,OnDestroy {

  message : string = '';
  
  subscription : Subscription;

  constructor(private data : DataService) { }

  ngOnInit(){

    this.subscription = this.data.currentMessage.subscribe(message => this.message = message)

  }

  ngOnDestroy(){

    this.subscription.unsubscribe();
    
  }

}
