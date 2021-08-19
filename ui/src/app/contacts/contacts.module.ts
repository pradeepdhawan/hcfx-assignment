import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { ContactsRoutingModule } from './contacts-routing.module';
import { LayoutComponent } from './layout.component';
import { ListComponent } from './list.component';
import { AddEditComponent } from './add-edit.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import {FormsModule} from '@angular/forms';


import {DatePipe} from '@angular/common';

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        ContactsRoutingModule,
        MatDatepickerModule,
        MatFormFieldModule,
        MatInputModule,
        MatNativeDateModule,    
        FormsModule      
    ],
    declarations: [
        LayoutComponent,
        ListComponent,
        AddEditComponent
    ],
    providers:[DatePipe]
})
export class ContactsModule { }