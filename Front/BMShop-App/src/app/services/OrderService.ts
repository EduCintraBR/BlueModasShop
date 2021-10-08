import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Order } from "../entities/Order";
import { Product } from "../entities/Product";
import { CartService } from "./CartService";
import { ClientService } from "./ClientService";

@Injectable({
    providedIn: 'root',
})

export class OrderService {  
    constructor(private http: HttpClient,
                private clientService: ClientService,
                private cartService: CartService) { }
    
    async GetOrderById(id: any): Promise<Order> {
        let order: any = this.http.get(`https://localhost:44304/api/v1/order/${id}`).toPromise()
        return order;
    }
    
    async SaveOrder(){
        var orderId: any = 0;  
        var idCli = localStorage.getItem('clientId')
        var client = await this.clientService.GetClient(idCli)
        var total = this.cartService.SumTotalValue()

        let order: Order = {
            "clientId": idCli,
            "name": client.name,
            "email": client.email,
            "phone": client.phone,
            "totalValue": total
          };

        orderId = await this.http.post<any>('https://localhost:44304/api/v1/order', order).toPromise();  

        let orderById = await this.GetOrderById(orderId.value.id);
        let products = await this.cartService.GetProductsByClientId(orderById.clientId)

        let completeOrder: object = {
            order,
            products
        }

        localStorage.setItem('order', JSON.stringify(completeOrder));
    }

    
}