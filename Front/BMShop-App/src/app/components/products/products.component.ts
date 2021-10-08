import { Component, OnInit } from '@angular/core';
import { IProductInCart } from 'src/app/entities/IProductInCart';
import { Product } from 'src/app/entities/Product';
import { CartService } from 'src/app/services/CartService';
import { ProductService } from 'src/app/services/ProductService';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  public produtos: Product[] = [];

  constructor(private productService: ProductService,
              private cartService: CartService) { }

  ngOnInit(): void {
   this.getProducts()
  }

  public getProducts(): void {
    this.productService.GetAllProducts().subscribe(
      response => this.produtos = response,
      error => console.log(error) 
    )
  }

  public AddProduct(prod: Product){
    let productToCart: IProductInCart = {
      id: prod.id,
      name: prod.name,
      price: prod.price,
      quantity: 1,
      totalValue: prod.price * 1,
      inList: true
    }

      this.cartService.AddToCart(productToCart)
  }

}
