class rtoDetails{
    constructor(reg, city){
        this.reg = reg;
        this.city = city;
    }
}
class rtoRepo{
    data = new Map();
    detailsRto(city){
        if(this.data.has(city)){
            return city
        }
    }
}