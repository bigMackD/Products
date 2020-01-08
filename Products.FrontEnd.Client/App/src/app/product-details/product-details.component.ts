import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../products/product.service';
import { IProduct } from '../products/product-response';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { UpdateProductRequest } from '../products/product-request';

@Component({
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  pageTitle = 'Product details'
  productForm: FormGroup;
  editMode: boolean = false;
 
  constructor(private route: ActivatedRoute,
    private productService: ProductService,
    private fb: FormBuilder) { }

  ngOnInit() {
    let id = +this.route.snapshot.paramMap.get('id');
    this.productService.getById(id).subscribe(data => {
      this.product = data.content;
      this.createForm();
    });
  }

createForm(){
  this.productForm = this.fb.group({
    name: new FormControl({
      value: this.product.name, disabled: true,
    }, Validators.required),

    releaseDate: new FormControl({
      value: this.product.releaseDate, disabled: true,
    }, Validators.required),

    price: new FormControl({
      value: this.product.price, disabled: true,
    }, Validators.required),

    code: new FormControl({
      value: this.product.code, disabled: true,
    }, Validators.required),

  });
}

  onEditClick(){ 
   this.productForm.enable();
   this.editMode = true;
  }

  onSaveClick(){ 
    this.productForm.disable();
    this.editMode = false;
    var request: UpdateProductRequest = {
      id: this.product.id,
      name: this.productForm.get('name').value,
      releaseDate: this.productForm.get('releaseDate').value,
      price: this.productForm.get('price').value,
      code: this.productForm.get('code').value
    };
    console.log(request);
   }

}
