import { Http,Headers,Response, RequestOptions } from '@angular/http'
import { Injectable } from '@angular/core';
import { Book } from '../Models/Book';

@Injectable()
export class BookService{

    http: Http;
    url : string;


    constructor(http :Http)
    {
        this.http = http;
        this.url = 'http://localhost:50493/api/Book'       
    }

    getAll()
    {
        return this.http.get(this.url)
                .map(res => res.json());
    }


    get(id)
    {
        return this.http.get(this.url + '/' + id)
                .map(res => res.json());
    }

    delete(id)
    {  
       return this.http.delete(this.url + '/' + id)
                  .map(res => res.json());
    }

    saveBook(book : Book)
    {
        debugger;
       if(book.id)
            return this.http.put(this.url,book,this.makeOptions())
                        .map(res => res.json());
       else
            return this.http.post(this.url,book,this.makeOptions())
                       .map(res => res.json());
    }

    makeOptions()
    {
        const headers = new Headers({
            'Content-Type': 'application/json; charset=utf-8'
        });

        return new RequestOptions({ headers: headers });
    }


}