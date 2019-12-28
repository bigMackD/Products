export interface IProduct {
  id: number;
  name: string;
  code: string;
  releaseDate: string;
  price: number;
  description: string;
  starRating: number;
  imageUrl: string;
}

export interface IProductResponse {
  success: boolean,
  errors: string[],
  content: IProduct[]
}

