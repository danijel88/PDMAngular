import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { ItemTypeFormComponent } from "./components/itemtype-form/itemtype-form.component";
import { ItemTypeService } from "./services/itemtype.service";
import { ItemFormComponent } from "./components/item-form/item-form.component";
import { MachineTypeService } from "./services/machinetype.service";


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        ItemTypeFormComponent,
        ItemFormComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'item-types/new', component: ItemTypeFormComponent },
            { path: 'item/new', component: ItemFormComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        ItemTypeService,
        MachineTypeService
    ]
})
export class AppModuleShared {
}

