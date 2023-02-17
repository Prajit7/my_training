import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Employee } from 'src/app/Models/employee';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-edit-emp',
  templateUrl: './edit-emp.component.html',
  styleUrls: ['./edit-emp.component.css']
})
export class EditEmpComponent implements OnInit {
  empObj:Employee={} as Employee;
  ImgUrl:string="";
  empId :string | null="";

  constructor(private service:EmployeeService,private activatedRoute : ActivatedRoute,private router:Router) {}
  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((param:ParamMap)=>{
      this.empId =param.get("id") ;
     })
     if(this.empId!=null){
      this.service.getEmployee(this.empId).subscribe((data:Employee)=>{
        this.empObj = data;
      })
     }
  }
  onFileChange(event:any){
    let reader = new FileReader();
    reader.readAsDataURL(event.target.files[0]);
    reader.onload=(_ev)=>{
      this.ImgUrl = reader.result as string;
      this.empObj.empPic=this.ImgUrl;
    }
  }

  update(){
    this.service.putEmployee(this.empObj.id,this.empObj).subscribe((data:Employee)=>{
      this.empObj=data;
      alert("Updated!!")
      this.router.navigate(['/'])
    })

}
}
