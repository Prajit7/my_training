class Details{
    static car=1000
    static truck = 1500
    static bus = 1200
    constructor(details,type){
        this.car=this.constructor.car
        this.truck=this.constructor.truck
        this.bus=this.constructor.bus
        this.details=details
        this.type = type
    }
}

var map = new Map()
map.set("car",2000)
map.set("truck",1500)
map.set("bus",1200)
// console.log(map)

class about{

    amount = []
    addNewDetail=(detail)=>this.amount.push(detail);
    getAllDetail=()=>this.amount

}


let a = new about()
a.addNewDetail(new Details("ka21",2000))
console.log(a.getAllDetail())