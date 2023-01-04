class food{
    constructor(food,number){
        this.food = food;
        this.number = number;
    }
}


class details{
    expense=[];//makes it a private field of the class
    addNewExpense=(expense)=>this.expense.push(expense);

}

const obj= new food();