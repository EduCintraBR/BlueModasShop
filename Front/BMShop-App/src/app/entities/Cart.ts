import { Product } from "./Product";

export class Cart {
    public products: Product[];
    public quantity: number;
    public TotalValue: number;

    constructor(){
        this.quantity = 0; 
        this.TotalValue = 0;
        this.products = [];
    }
}