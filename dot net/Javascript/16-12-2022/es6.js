var ex= 123;
console.log(ex)

let ex1 = 234
console.log(ex1)

for(var i=0; i<5 ; i++){
    console.log(i)

}
console.log(i) //even it can be used outside the scope


for(let j=0; j<5 ; j++){
    console.log(j)

}
//console.log(j) // can't be used outside the scope


function test() {
    let example = 111
    console.log(example)
    
}


//Automatic intializatiom
// var data;
// console.log(data) //with var data it does not give the error but ehere as in let it gives error
// let data;

// default parameters

function sampleFun(msg = "How are you?"){
    console.log(msg)
}

sampleFun()
sampleFun("Praj")


function createDiv(height = "350px", width = "45%", display = "inline-block",border = "10px solid red"){
    const div = document.createElement("div")
    div.style.height = height;
    div.style.width = width;
    div.style.display = display;
    div.style.border = border;

    // document.body.appendChild(div)  //11

    const area = document.querySelector("#divArea")     //22
    area.appendChild(div)
    return div
}


//Rest parameter
// function restFun(... args){
//     let res = 0;
//     for(const val of args)
//         res += val
//         return res
    
// }
// console.log(restFun(1,2,3))
// console.log(restFun(10,10,10,10))
// console.log(restFun(10))

// add only number

function restFun(... praj){

    return praj
        .filter((e) => typeof e === 'number')
        .reduce((prev,next) =>prev+next)
}
console.log(restFun(1,2,3))
console.log(restFun(10,10,10,10,28.5,"praj"))
console.log(restFun(10))


//spread operator

//rest is used to extract the remaining args function whereas the spread is to extract all the values of a collection

const value = [1,2,3,4]
const newValue = [0, ...value]
console.log(newValue);

const data = []
const states = ["kar","tg","tn","ap"]
const northState = ["up","jk"]

const india = [...states, ...northState]
console.log(india)

states.push(...northState)
console.log(states)



//Static function
// class staticExample{
//     static addFun = (v1,v2) => v1 + v2
// }
// console.log(staticExample.addFun(1,3))


// static with instance
class staticExample{
    //static
    static addFun = (v1,v2) => v1 + v2

    //instance
    instanceExample(){
        constructor.addFun(10,20)
    }
}
console.log(staticExample.addFun(10,20))


// const obj = new staticExample();
// obj.instanceExample();