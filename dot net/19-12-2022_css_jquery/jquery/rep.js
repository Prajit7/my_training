class Expense{
    constructor(id,detail,amount,date){
        this.id=id;
        this.detail=detail;
        this.amount=amount;
        this.date=date;
    }
}


class ExpenseManager{
    expense=[];//makes it a private field of the class
    addNewExpense=(expense)=>this.expense.push(expense);
    findExpenses=(detail)=>this.expense.filter((e) => e.detail.includes(detail));
    findExpenseByDate=(date)=>this.expense.filter((e)=>e.date==date)
    getAllExpenses=()=>this.expense;
    getExpenseById=(id)=>this.expense.find((e)=>e.id==id);
    modifyExpense=(id,expense)=>{
        let foundIndex=this.expense.findIndex(ex=>ex.id==id);
        if(foundIndex==1)throw'Expense not found to update';
        this.expense.splice(foundIndex,1,expense);
    }
}
const obj= new ExpenseManager();
obj.addNewExpense(new Expense(100,"Food at cafe",28000,new Date(2022,11,13)));
obj.addNewExpense(new Expense(101,"Food at cafe",28000,new Date(2022,11,13)));
obj.addNewExpense(new Expense(102,"Food at cafe",28000,new Date(2022,11,13)));
obj.addNewExpense(new Expense(103,"Food at hotel",28000,new Date(2022,11,12)));


// let data=obj.getAllExpenses();
// for(const ex in data) console.log(ex.id);
// console.log("Searching on Detail..");
// data=obj.findExpenses("hotel");
// for (const ex of data) console.log(ex.id);
// console.log("Searching for date");
// data=obj.findExpenseByDate(new Date(2022,11,12));
// for(const ex of data) console.log(ex.id);
// const ex = obj.getExpenseById(100);
// ex.detail="Modified with new Info";
// obj.modifyExpense(3,ex);
// data=obj.getAllExpenses();
// for(const ex of data) console.log(ex.detail);