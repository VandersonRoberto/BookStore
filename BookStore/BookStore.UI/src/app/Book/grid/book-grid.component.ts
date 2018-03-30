import { Component, OnInit } from '@angular/core';
import { BookService } from '../book.service';
import { Book } from '../../models/Book';

declare var swal: any;

@Component({
    selector: 'book-grid',
    templateUrl: './book-grid.component.html',
    providers: [BookService],
})

export class BookGridComponent {

    service: BookService;
    lstBooks : Book[];

    constructor(service: BookService) {
        this.service = service;

        this.ListBooks();
    }

    ListBooks() {
        
        this.service.getAll().subscribe(ret => {
            this.lstBooks = ret;
        });
    }

    delete(book : Book) {

        swal({
            title: "Atenção",
            text: "Prosseguindo o livro será removido. Deseja continuar ?",
            icon: "warning",
            buttons: true,
            dangerMode: true,
          })
          .then((willDelete) => {
            if (willDelete) {
                this.service.delete(book).subscribe(ret => {
                    swal("Livro Removido com Sucesso!", {
                        icon: "success",
                      });   

                      this.ListBooks();
                });
              
            } else {
              swal("Tudo bem o livro não será removido!");
            }
          });
    }

}
