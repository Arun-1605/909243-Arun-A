import { Component, ViewChild,AfterViewInit} from '@angular/core';
import { ChildComponent } from '../child/child.component';
@Component({
  selector: 'app-parent',
  template:  `
  <app-child [childMessage]="parentMessage"></app-child>
  <br>
  <h2>Message : {{ message }}</h2>
  <br>
  <h2>Message : {{ message1 }}</h2>
  <app-child (messageEvent)="receiveMessage($event)"></app-child>
  `,
  styleUrls: ['./parent.component.css']
})
export class ParentComponent implements AfterViewInit{

  //Sending data from Parent to child
  parentMessage = "message from parent"

  @ViewChild(ChildComponent) child;

  constructor() { }

  message:string='';

  message1:string='';
  
  ngAfterViewInit(){
    this.message=this.child.message
  } 

  receiveMessage($event) {
    this.message1 = $event
  }


}

