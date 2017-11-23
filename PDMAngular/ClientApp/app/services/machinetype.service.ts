import { Injectable } from '@angular/core';
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';

@Injectable()
export class MachineTypeService {

    constructor(private http: Http){}

    getMachineTypes() {
        return this.http
            .get('/api/machinetypes/')
            .map(res => res.json());
    }

}
