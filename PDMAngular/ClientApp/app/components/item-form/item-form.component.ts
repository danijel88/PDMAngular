
import { Component, OnInit } from '@angular/core';
import { ItemTypeService } from '../../services/itemtype.service';
import { MachineTypeService } from '../../services/machinetype.service';

@Component({
    selector: 'item-form',
    templateUrl: './item-form.component.html'
})
export class ItemFormComponent implements OnInit {
    itemTypes: any;
    machineTypes: any;
    item = {};

    constructor(private itemTypeService: ItemTypeService,
        private mahcineTypeService: MachineTypeService) {
        
    }

    ngOnInit() {
        this.itemTypeService.getItemTypes().subscribe(it => {
            this.itemTypes = it;
        });

        this.mahcineTypeService.getMachineTypes().subscribe(mt => {
            this.machineTypes = mt;
        });
    }


}
