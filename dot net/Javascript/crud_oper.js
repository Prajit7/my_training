// Create the global var 
const myBooks=[]
// myBooks.push("Demo") to check whether its working or not

// creating operation
function addItem(item){
    myBooks.push(item)

}

// read operation
// function getAll(){
//     return myBooks;
// }same to Above
const getAll=()=>myBooks


// Deleting
const deleteItem = (index) => myBooks.splice(index,1);  //if user want to delete as per requirement then (index,n)=>myBooks.splice(index,n)

//Updating

const updateItem=(index,item)=>{
    myBooks[index]=item;
}
