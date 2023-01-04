const myModule = require("./modules_node.js")  //creating module
const aliasFun = myModule.simpleFun;
const myTable = myModule.mathTable;
const empClass = myModule.employee;
aliasFun()

// myModule.simpleFun()

// myModule.mathTable(3)

myTable(3)

const empObj = new empClass(1,"Praj","Gokak")
empObj.display();