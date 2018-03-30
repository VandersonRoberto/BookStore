import { RouterModule, Routes } from '@angular/router';
import { BookSaveComponent } from './Book/save/book-save.component';
import { BookComponent } from './Book/book.component';


const appRoutes: Routes     = [

    { path: '', component: BookComponent },
    { path: 'CadastroLivro', component: BookSaveComponent},
    { path: 'CadastroLivro/:id', component: BookSaveComponent}

];

export const routing = RouterModule.forRoot(appRoutes);