
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";
import { ItemService } from "../../services/item.service";

@Component({
    templateUrl: './view-item.component.html'
})
export class ViewItemComponent implements OnInit {
    item: any;
    itemId: number;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private itemService: ItemService
    ) {
        route.params.subscribe(p => {
            this.itemId = +p['id'];
            if (isNaN(this.itemId) || this.itemId <= 0)
            {
                router.navigate(['/items']);
            }
        });
    }

    ngOnInit() {
        this.itemService.getItem(this.itemId)
            .subscribe(
                i => this.item = i,
                err => {
                    if (err.status == 404) {
                        this.router.navigate(['/items']);
                        return;
                    }
            });
    }

    delete() {
        if (confirm("Are you sure,it will be deleted also all Item History?")) {
            this.itemService.deleteItem(this.item.id)
                .subscribe(x => {
                    this.router.navigate(['/home']);
                });
        }
    }
}
