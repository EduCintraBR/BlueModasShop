import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/services/CartService';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  constructor(private cartService: CartService) { }
  
  public quantityCart: number = 0; 

  ngOnInit(): void {
    this.getQuantityCart();
  }

  getQuantityCart(){
    this.quantityCart =  this.cartService.GetCountListOfCart();
    return this.quantityCart;
  }

}
