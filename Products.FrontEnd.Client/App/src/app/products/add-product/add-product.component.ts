import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { AddProductRequest } from '../models/product-request';

@Component({
  selector: 'pm-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  productForm: FormGroup;

  constructor( private fb: FormBuilder,
    private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.createForm();
  }

  createForm(){
    this.productForm = this.fb.group({
      name: new FormControl([''], [Validators.required, Validators.minLength(2)]),
      code: new FormControl([''], Validators.required),
      releaseDate: new FormControl([''], Validators.required),
      description: new FormControl([''], Validators.required),
      price: new FormControl([''], Validators.required),
    });
  }

  onSubmitClick(){
    var request: AddProductRequest = {
      name: this.productForm.get('name').value,
      code: this.productForm.get('code').value,
      releaseDate: this.productForm.get('releaseDate').value,
      description: this.productForm.get('description').value,
      price: this.productForm.get('price').value
    }
    console.log(request);
  }
}
