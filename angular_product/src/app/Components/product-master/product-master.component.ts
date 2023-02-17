import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/Models/product';

@Component({
  selector: 'app-product-master',
  templateUrl: './product-master.component.html',
  styleUrls: ['./product-master.component.css']
})
export class ProductMasterComponent implements OnInit {
  products : Product[]=[];
  selectedPrd:Product={} as Product;
  ngOnInit(): void {
    this.products.push({id:1,name:"BLOOD CELL COUNTER",price:200000,pic:"./assets/Images/1.jpg"});
    this.products.push({id:2,name:"MICROSCOPE",price:100000,pic:"./assets/Images/2.jpg"});
    this.products.push({id:3,name:"Thermometer ",price:1000,pic:"./assets/Images/3.jfif"});
    this.products.push({id:4,name:"Sphygnomanometer",price:5000,pic:"./assets/Images/4.jfif"});
    this.products.push({id:5,name:" Pulse Oximeter",price:5000,pic:"./assets/Images/5.jpg"});
    this.products.push({id:6,name:"Nebuliser ",price:5000,pic:"./assets/Images/6.jpg"});
    this.products.push({id:7,name:"Humidifer ",price:5000,pic:"./assets/Images/7.jpg"});
    this.products.push({id:8,name:"Pulse Oximeter ",price:5000,pic:"./assets/Images/8.jpg"});
    this.products.push({id:9,name:"Oxygen Concentrator",price:5000,pic:"./assets/Images/9.jpg"});
    this.products.push({id:10,name:"Ultrasound Apogee",price:5000,pic:"./assets/Images/10.jpg"});

  }
 
  onEdit(prd:Product){
    this.selectedPrd = prd

  }

}
