function pushFunction() {
let list = [];

const ol=document.getElementById("lisItem");
list.push(document.getElementById("txtBook").value)



for(const item of list){
    const value="<li>"+item+"</li>"
    ol.innerHTML+=value;
}
}
