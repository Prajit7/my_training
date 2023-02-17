import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from 'src/app/Models/employee';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-add-emp',
  templateUrl: './add-emp.component.html',
  styleUrls: ['./add-emp.component.css']
})
export class AddEmpComponent {
  empObj:Employee={} as Employee;
  ImgUrl:string="";
  constructor(private sercice :EmployeeService,private router:Router ) {}

  //file
  onFileChange(event:any){
    let reader = new FileReader();
    reader.readAsDataURL(event.target.files[0]);
    reader.onload=(_ev)=>{
      this.ImgUrl = reader.result as string;
      this.empObj.empPic=this.ImgUrl;
    }
  }

  onAddEmployee(){
    this.sercice.postEmployee(this.empObj).subscribe((data:Employee)=>{
      this.empObj = data;
      alert("Data added!!")
      this.router.navigate(['/'])
    })
  }

}
