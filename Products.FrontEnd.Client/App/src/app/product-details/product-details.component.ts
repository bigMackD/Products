import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../products/product.service';
import { IProduct } from '../products/product-response';

@Component({
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  pageTitle = 'Product details'
  constructor(private route: ActivatedRoute,
    private productService: ProductService) {}

  ngOnInit() {
    let id = +this.route.snapshot.paramMap.get('id');
    this.productService.getById(id).subscribe(data => {
      this.product = data.content
    });
  }

}
