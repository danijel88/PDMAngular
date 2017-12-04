
import { Injectable } from '@angular/core';
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';
import { SaveItem } from "../models/SaveItem";

@Injectable()
export class ItemService {
    constructor(private http: Http) { }

    createItem(item) {
        return this.http
            .post('/api/items/', item)
            .map(res => res.json());
    }

    getItem(id)
    {
        return this.http.get('/api/items/' + id)
            .map(res => res.json());
    }

    updateItem(item: SaveItem) {
        return this.http.put('/api/items/'+ item.id, item)
            .map(res => res.json());
    }

}