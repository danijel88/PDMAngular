import { NgModule, ErrorHandler } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { ToastyModule } from 'ng2-toasty';


import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { ItemTypeFormComponent } from "./components/itemtype-form/itemtype-form.component";
import { ItemTypeService } from "./services/itemtype.service";
import { ItemFormComponent } from "./components/item-form/item-form.component";
import { MachineTypeService } from "./services/machinetype.service";
import { ItemService } from "./services/item.service";
import { AppErrorHandler } from "./components/app.error-handler";


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
        ToastyModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'item-types/new', component: ItemTypeFormComponent },
            { path: 'item/new', component: ItemFormComponent },
            { path: 'item/:id', component: ItemFormComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler},
        ItemTypeService,
        MachineTypeService,
        ItemService
    ]
})
export class AppModuleShared {
}

