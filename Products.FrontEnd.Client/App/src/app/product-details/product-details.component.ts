import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../products/product.service';
import { IProduct } from '../products/product-response';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

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
    //TODO SAVE LOGIC
   }

}
