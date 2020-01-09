import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../products/product.service';
import { IProduct, IProductResponse } from '../products/product-response';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { UpdateProductRequest } from '../products/product-request';
import { MatSnackBar, MatDialog, MatDialogConfig } from '@angular/material';
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';

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
    private fb: FormBuilder,
    private snackBar: MatSnackBar,
    private dialog: MatDialog,
    private router: Router) { }

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

  onCancelClick(){
    this.productForm.disable();
    this.editMode = false;
  }

  onSaveClick() {
    if (this.productForm.valid) {
      var request: UpdateProductRequest = {
        id: this.product.id,
        name: this.productForm.get('name').value,
        releaseDate: this.productForm.get('releaseDate').value,
        price: this.productForm.get('price').value,
        code: this.productForm.get('code').value
      };
      this.productService.update(request).subscribe(response => this.handleProductUpdate(response));
    }
  }

  handleProductUpdate(response: IProductResponse) {
    if (response.success) {
      this.productForm.disable();
      this.editMode = false;
      this.snackBar.open('Product updated!', '', { duration: 2000 })
      this.product.name = response.content.name;
    }
    else {
      this.snackBar.open('Error while updating product!', '', { duration: 2000 })
    }
  }

  openDialog() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;

    const dialogRef = this.dialog.open(ConfirmDialogComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(
      data => {
        if(data){
          this.removeProduct();
        }
      }
  );    
}

  removeProduct(){
    //TODO ADD REMOVE LOGIC
    this.router.navigateByUrl('/products');
  }
}