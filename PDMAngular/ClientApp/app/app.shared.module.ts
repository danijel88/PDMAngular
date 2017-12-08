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
import { ItemListComponent } from "./components/item-list/item-list.component";
import { ViewItemComponent } from "./components/view-item/view-item.component";


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        ItemFormComponent,
        ItemListComponent,
        ItemTypeFormComponent,
        HomeComponent,
        ViewItemComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ToastyModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'items', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'item-types/new', component: ItemTypeFormComponent },
            { path: 'items/new', component: ItemFormComponent },
            { path: 'items/edit/:id', component: ItemFormComponent },
            {path:  'items/:id',component:ViewItemComponent},
            { path: 'items', component: ItemListComponent },
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

