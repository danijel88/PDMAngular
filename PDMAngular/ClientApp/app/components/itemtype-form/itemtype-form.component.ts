
import { Component, OnInit } from '@angular/core';
import { ItemTypeService } from "../../services/itemtype.service";

@Component({
    selector: 'itemtype-form',
    templateUrl: 'itemtype-form.component.html'
})
export class ItemTypeFormComponent implements OnInit {

    itemTypes: any;
    itemType = {};
    constructor(private itemTypeService: ItemTypeService) {
    }

    ngOnInit() {
        this.itemTypeService.getItemTypes().subscribe(it => {
            this.itemTypes = it;
            console.log("ITEM TYPES", this.itemTypes);
        });
        
    }
}
