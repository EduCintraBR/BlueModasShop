import { ProductCart } from "./ProductCart";

export class Product {
    public id: number;
    public name: string;
    public price: number;
    public imgUrl: string;
    public productsCarts: ProductCart[];

    constructor(){
        this.id = 1;
        this.name = ''; 
        this.price = 0;
        this.imgUrl = '';
        this.productsCarts = []
    }
}