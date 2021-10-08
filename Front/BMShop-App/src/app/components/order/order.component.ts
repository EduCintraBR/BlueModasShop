import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
  public finalOrder: any = '';
  constructor() { }

  ngOnInit(): void {
    this.GetOrderFromLS();
  }

  GetOrderFromLS() {
    var temp = localStorage.getItem('order');
    this.finalOrder = JSON.parse(temp)
  }

}
