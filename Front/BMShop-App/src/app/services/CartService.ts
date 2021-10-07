import { Injectable } from "@angular/core";
import { IProductInCart } from "../entities/IProductInCart";

@Injectable({
    providedIn: 'root',
})

export class CartService {
    constructor() { }

    private productList: IProductInCart[] = [];
    private totalValue: number = 0;

    AddToCart(prod: IProductInCart){
        let inList: boolean = false;

        if (this.productList.length > 0) {
            this.productList.forEach(p => {
                if (p.id == prod.id) {
                    inList = true;
                }
            });
        }
        
        if (inList == false) {
            var list = this.GetProductList()
            if (list != null && list.length > 0) {
                list.push(prod)
                localStorage.setItem('productsList', JSON.stringify(list))
            } else {
                this.productList.push(prod);
                localStorage.setItem('productsList', JSON.stringify(this.productList))
            }
            console.log(list)
        } else {
            alert(`The product ${prod.name} it's already in cart`)
        }
    }

    SumTotalValue(){
        let sum = 0;
        this.productList.map(p => {
            sum += p.price
        })

        this.totalValue = sum;
        return sum;
    }

    GetCountListOfCart(){
        return this.GetProductList().length;
    }

    GetProductList(){
        const products: any = localStorage.getItem('productsList');
        return JSON.parse(products)
    }
}