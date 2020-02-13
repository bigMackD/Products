export class UpdateProductRequest{
   id: number;
   name: string;
   code: string;
   releaseDate: Date;
   price: number; 
}

export class DeleteProductRequest{
   id: number;
}

export class AddProductRequest{
   name: string;
   code: string;
   releaseDate: Date;
   description: string;
   price: number; 
}