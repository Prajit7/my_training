console.log("Testing of nodejs")

const addFun  = (v1,v2)=>v1+v2;

console.log("Addition is "+addFun(20,10));

const data = [
    {
        "id": 1,
        "bookTitle": "Atomic Habit",
        "price": 450,
        "author": "James Clever"
      },
      {
        "id": 2,
        "bookTitle": "Lifes Amazing Secrete",
        "price": 450,
        "author": "Gopal Das"
      },
      {
        "id": 3,
        "bookTitle": "Karma",
        "price": 450,
        "author": "Sadhaguru"
      }
]

console.table(data);