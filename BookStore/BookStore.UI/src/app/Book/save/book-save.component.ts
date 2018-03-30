import { OnInit, Component, ViewChild } from '@angular/core';
import { Book } from '../../Models/Book';
import { BookService } from '../book.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'book-save',
    templateUrl: './book-save.component.html',
    providers: [BookService],
})

export class BookSaveComponent implements OnInit {


    model : Book;
    route : ActivatedRoute;
    successMessage : string;
    errorMessage : string;

    constructor(private service: BookService, route : ActivatedRoute) {
        this.route = route;
    }

    ngOnInit(): void {
        
        this.model = new Book();
        this.successMessage = "";
        this.errorMessage = "";

        this.route.params.subscribe(param => {
            let id = param['id'];

            this.service.get(id).subscribe(ret => {
                
                this.model = ret;
            });
        });

    }

    save()
    {   
        this.successMessage = "";
        this.errorMessage = "";

        this.service.saveBook(this.model).subscribe(ret => {
            if(ret.success)
                this.successMessage = ret.message;
            else
                this.errorMessage = ret.message;

            this.model = new Book();    
        },fail => {
            this.errorMessage = "Falha ao salvar Livro !";
        });
    }
}
