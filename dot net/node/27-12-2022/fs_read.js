const fs = require("fs")

const file = "./modules_calling.js"

function fileReadSync() {
    const contents = fs.readFileSync(file, "utf-8")  //sync
    console.log(contents)
}

function fileReadAsync() {

    fs.readFile(file, "utf-8", function (err, data) {        //async default(it doesnt wait for completion)
        if (err)
            console.error(err)
        else
            console.log(data)
    })

}

// fileReadSync()
// fileReadAsync()
console.log("Code execute after file read")

//Sync
const obj = {"id":1,"name":"praj","add":"Gokak"}

function writeFile(){   
    fs.writeFileSync("sample.txt","Adding the content to the sample file","utf-8")
    fs.writeFileSync("sampleobj.txt",JSON.stringify(obj),"utf-8")
}
// writeFile()


function writeFileAsync(){
    fs.writeFile("sampleAsync.txt","Async file example",(err)=>{
        if(err) console.log(err)
    })
}
// writeFileAsync()

function appendFile(){
    fs.appendFileSync("sample.txt","\n This is the new appended text\n","utf-8")

}
// appendFile()


function appendAsync(){
    fs.appendFile("sample.txt","\nAppending the Async version\n",(err) =>{
        if(err) console.log(err)
    })
}
// appendAsync()