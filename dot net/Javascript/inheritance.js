//basic example

// const BaseClass = class{
//     constructor(){
//         console.log("Base Class that extends another")
//     }
//     display = () => console.log("Base class function")
// }

// class derivedClass extends BaseClass{
//     displayAnother = () => console.log("Derived class Function");
// }

// const data=new derivedClass();
// data.display();
// data.displayAnother()


//different example
const BaseClass = class{
    data1 = "Prajit"
    data2 = 50000
    constructor(){
        console.log("Base Class that extends another")
    }
   
   
    toString(){
        return `${this.data1} and ${this.data2}`
    }
    display = () => console.log("Base class function")
}

class derivedClass extends BaseClass{
    data3 = true;
    displayAnother = () => console.log("Derived class Function");

    toString(){
        let data = super.toString();
        data += this.data3;
        return data;
    }
}

const data=new derivedClass();
data.display();
data.displayAnother()
console.log(data.toString())