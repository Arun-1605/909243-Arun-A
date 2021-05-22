import { Component } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  
  data: Observable<number>;  
  numArray: number[] = [];  
  errors: boolean;  
  finished: boolean;  
  
  fetchData() {  
    this.data = new Observable(observer => {  
      setTimeout(() => { observer.next(10); }, 1000),  
        setTimeout(() => { observer.next(20); }, 2000),  
        setTimeout(() => { observer.complete(); }, 3000);  
    });  
    const sub = this.data.subscribe((value) => this. numArray.push(value),  
      error => this.errors = true,  
      () => this.finished = true);  
  }  

}
