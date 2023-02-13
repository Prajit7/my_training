import { Component } from '@angular/core';

@Component({
  selector: 'app-conent',
  templateUrl: './conent.component.html',
  styleUrls: ['./conent.component.css']
})
export class ConentComponent {
  value1 : number = 123;
  value2 : number = 23;
  result : number = this.value1 + this.value2; //local member
  
  //Function of component
  onClick = ()=>{
    alert("Clicked Event occured");
  }
  
  onAddFunc(){
    this.value1 = Number(prompt("Enter the First value"));
    this.value2 = Number(prompt("Enter the second value"));
    this.result = this.value1 + this.value2;
  }
}
