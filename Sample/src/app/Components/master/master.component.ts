import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/Models/employee';


@Component({
  selector: 'app-master',
  templateUrl: './master.component.html',
  styleUrls: ['./master.component.css']
})
export class MasterComponent implements OnInit  {
  employees : Employee[]=[]
  selectedEmp:Employee={} as Employee;
  ngOnInit(): void {
this.employees.push({id:1,Name:"MS DHONI",Address:"Chennai",Salary:450000,Pic:"./assets/Images/dhoni.jfif"});
this.employees.push({id:2,Name:"Rohit Sharma",Address:"Mumbai",Salary:400000,Pic:"./assets/Images/rohit.jfif"});
this.employees.push({id:3,Name:"Ashwin",Address:"Delhi",Salary:350000,Pic:"./assets/Images/ashwin.jfif"})
this.employees.push({id:4,Name:"Hardik Pandya",Address:"Mumbai",Salary:350000,Pic:"./assets/Images/hardik.jfif"})
this.employees.push({id:5,Name:"Rishab Pant",Address:"Delhi",Salary:350000,Pic:"./assets/Images/rishab.jfif"})
this.employees.push({id:6,Name:"Ruturaj Gaikwad",Address:"Chennai",Salary:350000,Pic:"./assets/Images/ruturaj.jfif"})
this.employees.push({id:7,Name:"Surya K",Address:"Mumbai",Salary:350000,Pic:"./assets/Images/sky.jfif"})
this.employees.push({id:8,Name:"KL Rahul",Address:"Lucknow",Salary:350000,Pic:"./assets/Images/kl.jfif"})


    
  }
  //for selecting emp
  onEdit(emp:Employee){
    this.selectedEmp = emp

  }

 

}
