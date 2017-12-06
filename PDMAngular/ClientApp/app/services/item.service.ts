
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

    deleteItem(id)
    {
        return this.http.delete('/api/items/' + id)
            .map(res => res.json());
    }

    //Client side filtering
    //getItems()
    //{
    //    return this.http.get('/api/items')
    //        .map(res => res.json());
    //}

    //server side filtering
    getItems(filter)
    {
   
        return this.http.get('/api/items' + '?' + this.toQueryString(filter))
            .map(res => res.json());
    } 

    toQueryString(obj) {
        var parts: any[] = [];
        
        for (var property in obj)
        {
            var value = obj[property];
            console.log(value);
            if (value != null && value != 'undefined')
                   parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
            
        }
        return parts.join('&');
    }

}