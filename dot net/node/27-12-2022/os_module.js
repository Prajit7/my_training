const os = require("os")
console.log(os.version())
console.log(os.hostname())
console.log(os.arch())


const cpus = os.cpus()
for (const info of cpus) {
    console.log(JSON.stringify(info))
}

const gb = os.totalmem()
// console.log("GB is: "+gb/0.01)
console.log(os.totalmem())
console.log(os.freemem())
console.log(os.userInfo())