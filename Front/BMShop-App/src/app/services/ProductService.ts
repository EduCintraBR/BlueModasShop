import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IProductInCart } from "../entities/IProductInCart";
import { Product } from "../entities/Product";

@Injectable({
    providedIn: 'root',
})

export class ProductService {  
    constructor(private http: HttpClient) { }
    
    GetAllProducts(){
        return this.http.get<Product[]>('https://localhost:44304/api/v1/products');
    }

    
}