import { HttpClient } from "@angular/common/http";
import { ThisReceiver } from "@angular/compiler";
import { Injectable } from "@angular/core";
import { Cart } from "../entities/Cart";
import { IProductInCart } from "../entities/IProductInCart";

@Injectable({
    providedIn: 'root',
})

export class CartService {
    constructor(private http: HttpClient) { }

    private productList: IProductInCart[] = []
    private totalValue: number = 0;

    AddToCart(prod: IProductInCart){
        let inList: boolean = false;

        if (this.productList.length > 0) {
            var prods = this.GetProductList()
            prods.forEach((p:any) => {
                if (p.id == prod.id) {
                    inList = true;
                }
            });
        }
        console.log('lista antes')
        console.log(this.productList)
        if (inList == false) {
            var list = this.GetProductList()
            if (list != null && list.length > 0) {
                list.push(prod)
                localStorage.setItem('productsList', JSON.stringify(list))
            } else {
                this.productList.push(prod);
                localStorage.setItem('productsList', JSON.stringify(this.productList))
            }
        } else {
            alert(`O produto ${prod.name} já esta no carrinho!`)
        }
    }

    SumTotalValue(){
        let values = this.GetProductList()
        let sum = 0;
        values.map((p: any) => {
            sum += p.totalValue
        })
        return sum;
    }

    GetCountListOfCart(){
        return this.GetProductList().length
    }

    GetProductList(){
        const products: any = localStorage.getItem('productsList');
        return JSON.parse(products)
    }

    async GetProductsByClientId(id: any) {
        let products: any = await this.http.get(`https://localhost:44304/api/v1/cart/get-by-client-id/${id}`).toPromise();
        return products;
    }

    async SaveCart(){
        var clientId = localStorage.getItem('clientId');
        var products = this.GetProductList();
        var carts: Cart[] = []
        
        products.forEach(function (p: any, i: any) {
            let obj: Cart = {
              "id": p.id,
              "name": p.name,
              "price": p.price,
              "quantity": p.quantity,
              "TotalValue": p.totalValue,
              "clientId": clientId
            }
            carts.push(obj)
        });

        await this.http.post<any>('https://localhost:44304/api/v1/cart/save-cart', carts).subscribe(
            response => {
                if (response) {
                    if (response == true) {
                        localStorage.setItem('productsList', "[]")
                    }
                }
            },
            error => {
                console.log(error)
            }
        )
    }
}