import { Component ,Input,Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'app-child',
  template: `
    <h2>{{childMessage}}</h2>
     <br>
     <button (click)="sendMessage()">Send Message</button>
  `,
  styleUrls: ['./child.component.css']
})
export class ChildComponent{

  //Receiving data from parent
 @Input('childMessage') childMessage:string=""

 //Sending data from child to parent
 message='Hello from child!';

 message1:string="Using Event Emitter"

 //Sending data using Output Emitter
 @Output() messageEvent = new EventEmitter<String>();

 constructor() { }

 sendMessage() {
  this.messageEvent.emit(this.message1)
}


}
