const data=new Map()
function addFood(type,no){
    if(data.has(type)){
        let count=data.get(type)
        count+=1
        data.set(type,count)
    }else{
        data.set(type,1)
    }
}
function getdetails(type){
    let amt=0;
    const count=data.get(type)
    switch (type) {
        case "masala dosa":
         a=60;   
        amt=count*50
            break;
        case "idli":
        b=40;    
        amt=count*40
            break;
        case "uppit":
        c=100    
        amt=count*25
            break;    
        default:
            break;
    }
    return amt;
}