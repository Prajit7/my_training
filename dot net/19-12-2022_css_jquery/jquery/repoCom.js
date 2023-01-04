class Expense{
    static no =0;
    constructor(details,amount,date){
        this.id = ++Expense.no;
        // this.id = id;
        this.details = details;
        this.amount= amount;
        this.date = date;
    }
}

class expenseManager{
    expenses = []
    addNewExpense = (expense) => this.expenses.push(expense);

    findExpense = (detail) => this.expenses.filter((e)=>e.details.includes(detail));

    findExpenseByDate  = (date) =>this.expenses.filter((e)=>e.date.getTime() == date.getTime())

    getAllExpenses = () =>this.expenses;

    getExpenseById = (id) => this.expenses.find((e)=>e.id ==id);

    modifyExpense = (id,expense) =>{
        let foundIndex = this.expenses.findIndex(ex=>ex.id == id);
        if(foundIndex == -1) throw "Expense not Found"
        this.expenses.splice(foundIndex,1,expense);

    }
}

const obj = new expenseManager();
obj.addNewExpense(new Expense("Rent",10000,new Date(2022,01,01)))
obj.addNewExpense(new Expense("bus",2000,new Date(2022,01,01)))
obj.addNewExpense(new Expense("food",5000,new Date(2022,01,01)))



let data = obj.getAllExpenses()

for(const ex of data) console.log(ex.id);
console.log("Searching on Details")
data = obj.findExpense("bus")

for(const ex of data) console.log(ex.id);
console.log("Search date")
data = obj.findExpenseByDate(new Date(2022,01,01))
for(const ex of data) console.log(ex.id);
const ex = obj.getExpenseById(2);
ex.detail="Modified"
obj.modifyExpense(1,ex)
data = obj.getAllExpenses();
for(const ex of data) console.log(ex.detail);