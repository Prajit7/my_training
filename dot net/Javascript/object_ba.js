let obj = {}
obj.id = "1";
obj.name = "tname"
obj.address = "taddress"
obj.salary=50000

for(const key in obj) console.log(obj[key])



//To display object in string manner we use JSON.stringfy

console.log(JSON.stringify(obj))


//Using class keyword
//For using class we can create a prototype and then can create a object for that prototype. he prototype is called as class and the object id called as the instance of the class


class Employee{
    constructor(id,name,address,salary){
        this.empId=id;
        this.empName=name;
        this.empAdd=address;
        this.empSalary=salary;
    }
}

const empobj = new Employee(1,"Prajit","Belgaum",500000)