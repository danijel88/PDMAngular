import * as _ from 'underscore';
import { Component, OnInit } from '@angular/core';
import { ItemTypeService } from '../../services/itemtype.service';
import { MachineTypeService } from '../../services/machinetype.service';
import { ItemService } from "../../services/item.service";
import { ToastyService } from "ng2-toasty";
import { ActivatedRoute, Router } from "@angular/router";
import { Observable } from "rxjs/Observable";
import 'rxjs/add/Observable/forkJoin';
import { SaveItem } from "../../models/SaveItem";
import { Item } from "../../models/item";
import { Status } from "../../models/status";

@Component({
    selector: 'item-form',
    templateUrl: './item-form.component.html'
})
export class ItemFormComponent implements OnInit {
    itemTypes: any[];
    machineTypes: any[];
    item: SaveItem = {
        id: 0,
        internalCode: '',
        description: '',
        band: 0,
        color: '',
        madeBy: '',
        enter: 0,
        exit: 0,
        thickness: 0,
        machineTypeId: 0,
        itemTypeId: 0,
        elastic: false,
        name: '',
        status: 0
    };

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private itemTypeService: ItemTypeService,
        private mahcineTypeService: MachineTypeService,
        private itemService: ItemService,
        private tostyService: ToastyService) {

        route.params.subscribe(p => {
            this.item.id = +p['id'] || 0;
        });

    }

    ngOnInit() {

        var sources = [
            this.itemTypeService.getItemTypes(),
            this.mahcineTypeService.getMachineTypes(),
        ];

        if (this.item.id)
            sources.push(this.itemService.getItem(this.item.id));



        Observable.forkJoin(sources).subscribe(data => {
            this.itemTypes = data[0];
            this.machineTypes = data[1];
            if (this.item.id)
                this.setItem(data[2]);
        }, err => {
            if (err.status == 404)
                this.router.navigate(['/home'])
        });

    }

    submit() {

        if (this.item.id) {
            this.itemService.updateItem(this.item)
                .subscribe(x => {
                    this.tostyService.success({
                        title: 'Success',
                        msg: 'The Item was successfully updated.',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                });
        } else {
            this.itemService.createItem(this.item)
                .subscribe(x => this.item = x);
        }
        //navigate to the list
        //this.router.navigate(['/item/', this.item.id]);

    }

    private setItem(i: Item) {
        this.item.id = i.id;
        this.item.internalCode = i.internalCode;
        this.item.description = i.description;
        this.item.enter = i.enter;
        this.item.exit = i.exit;
        this.item.thickness = i.thickness;
        this.item.band = i.band;
        this.item.color = i.color;
        this.item.madeBy = i.madeBy;
        this.item.itemTypeId = i.itemType.id;
        this.item.machineTypeId = i.machineType.id;
        this.item.status = i.status;
    }




}
