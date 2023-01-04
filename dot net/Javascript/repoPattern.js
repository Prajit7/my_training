
class Employee{
    constructor(id,name,address,salary){
        this.empId=id;
        this.empName=name;
        this.empAdd=address;
        this.empSalary=salary;
    }
}


class EmpRepo{
    // create an array object
    data = []
    addEmployee(emp){
        
        this.data.push(emp)
    }

//     getAllEmployees=()=>{ return this.data}

//     getEmployee(id){
//         // return this.data.find((e) => e.empId = id) 

//         for(const emp of this.data){
//             if(emp.empId == id){
//                 return emp;
//             }
//             throw `Employee ID ${id} not found`;
//         }

//     }
// }
getAllEmployees = () => this.data;

getEmployee(id){
    for(const emp of this.data){
        if(emp.empId == id)
          return emp;
    }
    throw `Employee by ID ${id} not found`;
}
updateEmployee(emp){
    for(const empRec of this.data){
        if(emp.empId == empRec.empId){
            empRec.empAdd = emp.empAdd;
            empRec.empSalary = emp.empSalary;
            empRec.empName = emp.empName;
            return;

        }

    }throw "Not Found"
}



}




//Testing
let instance=new EmpRepo();
instance.addEmployee(new Employee(1,"praj","bgm",450000));
instance.addEmployee(new Employee(2,"Ash","blore",50000));
instance.addEmployee(new Employee(3,"Ang","blore",10000));
instance.addEmployee(new Employee(4,"Shri","gkk",10000));


const data = instance.getAllEmployees()
for(const emp of data) console.log(emp)