import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Client } from "../entities/Client";

@Injectable({
    providedIn: 'root',
})

export class ClientService {  
    private client: Client;

    constructor(private http: HttpClient) { }
    
    async GetClient(id: any){
        this.client = await this.http.get<Client>(`https://localhost:44304/api/v1/clients/${id}`).toPromise()
        return this.client
    }
    
    async SaveClient(model: Client){
        let client  = await this.http.post<any>('https://localhost:44304/api/v1/clients', model).toPromise();
        localStorage.setItem('clientId', client.id)
    }
}