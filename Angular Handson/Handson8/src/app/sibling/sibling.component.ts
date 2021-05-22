import { Component, OnDestroy, OnInit } from '@angular/core';
import { DataService } from "../data.service";
import { Subscription } from 'rxjs';
@Component({
  selector: 'app-sibling',
  template : ` <br>
      <h2> Sibling Component : {{message}}</h2>
      <button (click)="newMessage()"> New Message </button>
  `,
  styleUrls: ['./sibling.component.css']
})
export class SiblingComponent implements OnInit,OnDestroy {

  message : String = '';

  subscription : Subscription;

  constructor(private data : DataService) { }

  ngOnInit(){

    this.subscription = this.data.currentMessage.subscribe(message => this.message = message)

  }

  ngOnDestroy(){

    this.subscription.unsubscribe();

  }

  newMessage(){
    this.data.changeMessage("Hello from Sibling");
  }

}
