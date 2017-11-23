
import { Injectable } from '@angular/core';
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';

@Injectable()
export class ItemTypeService {

    constructor(private http: Http) { }

    getItemTypes() {
        return this.http
            .get('/api/itemtypes/')
            .map(res => res.json());
    }
}
