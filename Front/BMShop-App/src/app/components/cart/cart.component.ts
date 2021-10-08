import { Component, OnInit } from '@angular/core';
import { IProductInCart } from 'src/app/entities/IProductInCart';
import { CartService } from 'src/app/services/CartService';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  constructor(private cartService: CartService) { }
  
  public products: IProductInCart[] = this.cartService.GetProductList()
  public totalValue: number = this.cartService.SumTotalValue();
  public finalProductList: IProductInCart[] = []

  ngOnInit(): void {
    this.products = this.cartService.GetProductList()
  }

  IncreaseQuantityInList(id: number){
    let products = this.cartService.GetProductList()

    let product = products.filter((product: any) => product.id == id);
    product[0].quantity += 1;
    product[0].totalValue = product[0].quantity * product[0].price;

    let index = products.findIndex((product: any) => product.id == id)
    products[index] = product[0]

    localStorage.setItem('productsList', JSON.stringify(products))
    this.products = this.cartService.GetProductList()
  }

  DecreaseQuantityInList(id: number){
    let products = this.cartService.GetProductList()

    let product = products.filter((product: any) => product.id == id);
    if(product[0].quantity == 1){
      let index = products.findIndex((product: any) => product.id == id)
      products.splice(index,1)
    } else {
      product[0].quantity -= 1;
      product[0].totalValue = product[0].quantity * product[0].price;
      let index = products.findIndex((product: any) => product.id == id)
      products[index] = product[0]
    }

    localStorage.setItem('productsList', JSON.stringify(products))
    this.products = this.cartService.GetProductList()
  }

  Checkout(){
    this.finalProductList = this.cartService.GetProductList()
  }
}
