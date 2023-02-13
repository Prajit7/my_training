import { Component, Input } from '@angular/core';
import { Product } from 'src/app/Models/product';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent {
  @Input() selectedPrd : Product = {} as Product
}
