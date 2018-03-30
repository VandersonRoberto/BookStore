import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookComponent } from './book.component'
import { BookGridComponent } from './grid/book-grid.component';
import { BookSaveComponent } from './save/book-save.component';
import { BookService } from './book.service';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
    imports: [
        HttpModule,
        CommonModule,
        RouterModule,
        FormsModule
    ],
    declarations: [
        BookComponent,
        BookGridComponent,
        BookSaveComponent
    ],
    exports: [
        BookComponent,
        BookGridComponent,
        BookSaveComponent
    ],
    providers:[
        BookService
    ]
})
export class BookModule { }
