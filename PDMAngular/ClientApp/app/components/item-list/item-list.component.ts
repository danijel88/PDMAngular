
import { Component, OnInit } from '@angular/core';
import { ItemService } from "../../services/item.service";
import { Item } from "../../models/item";
import { KeyValuePair } from "../../models/KeyValuePair";
import { ItemTypeService } from "../../services/itemtype.service";
import { MachineTypeService } from "../../services/machinetype.service";

@Component({
    templateUrl: './item-list.component.html'
})
export class ItemListComponent implements OnInit {
    items: Item[];
    //used for client side filtering
    //allItems: Item[];
    itemTypes: KeyValuePair[];
    machineTypes: KeyValuePair[];
    filter: any = {};

    constructor(private itemService: ItemService,
        private itemTypeService: ItemTypeService,
    private machineTypeService: MachineTypeService) {

    }

    ngOnInit() {

        this.itemTypeService.getItemTypes().subscribe(itemTypes => this.itemTypes = itemTypes);

        this.machineTypeService.getMachineTypes().subscribe(mt => this.machineTypes = mt);

        //client side filtering
        //this.itemService.getItems()
        //    .subscribe(items => this.items = this.allItems = items);

        //Server side filtering
        this.populateItems();
    }


    //Client side filtering
    //onFilterChange()
    //{
    //    var items = this.allItems;

    //    if (this.filter.itemTypeId)
    //        items = items.filter(i => i.itemType.id == this.filter.itemTypeId);

    //    if (this.filter.machineTypeId)
    //        items = items.filter(i => i.machineType.id == this.filter.machineTypeId);

    //    this.items = items;
    //}

    //Server side filtering
        onFilterChange()
        {
            this.populateItems();
        }
        private populateItems()
        {
            
            //server side filtering
            this.itemService.getItems(this.filter)
                .subscribe(items => this.items = items);
        }

    resetFilter()
    {
        this.filter = {};
        this.onFilterChange();
        }


}
