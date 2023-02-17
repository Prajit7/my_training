import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from 'src/app/Models/employee';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-emp-manager',
  templateUrl: './emp-manager.component.html',
  styleUrls: ['./emp-manager.component.css']
})
export class EmpManagerComponent implements OnInit {
  empList : Employee[]=[];
  constructor(private service :EmployeeService ) { }

  ngOnInit(): void {
   let observable =  this.service.getAllEmployees();
   observable.subscribe((data:Employee[])=>{
    this.empList = data;
   })
  }
  onDelete(id:number){
    this.service.deleteEmployee(id).subscribe(()=>{
      
    });
  }

}
