import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { CartService } from 'src/app/services/CartService';
import { ClientService } from 'src/app/services/ClientService';
import { OrderService } from 'src/app/services/OrderService';

@Component({
  selector: 'app-customer-editor',
  templateUrl: './customer-editor.component.html',
  styleUrls: ['./customer-editor.component.css']
})
export class CustomerEditorComponent {
  constructor(private router: Router,
              private clientService: ClientService,
              private orderService: OrderService,
              private cartService: CartService) {}

  form = new FormGroup({
    name: new FormControl(''),
    email: new FormControl(''),
    phone: new FormControl(''),
  });

  

  async SendForm(){
    await this.clientService.SaveClient(this.form.value)
    this.form.reset();

    await this.cartService.SaveCart()
    await this.orderService.SaveOrder();
    this.router.navigate(['order'])
  }
}
