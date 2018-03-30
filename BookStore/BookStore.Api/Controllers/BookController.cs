using BookStore.Domain.Commands;
using BookStore.Domain.Entities;
using BookStore.Domain.Handlers;
using BookStore.Domain.Repositories;
using BookStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.Api.Controllers
{
    public class BookController : ApiController
    {
        private readonly IBookRepository _repository;
        private readonly CreateBookHandler _createHandler;
        private readonly UpdateBookHandler _updateHandler;

        public BookController(IBookRepository bookRepository , CreateBookHandler createHandler, UpdateBookHandler updateHandler)
        {
            _repository = bookRepository;
            _createHandler = createHandler;
            _updateHandler = updateHandler;
        }


        public List<Book> Get()
        {
            return _repository.GetAll();
        }


        public Book Get(Guid id)
        {
            return _repository.Get(id);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }


        public ICommandResult Post(CreateBookCommand command)
        {

            var result = (CommandResult)_createHandler.Handle(command);
            return result;
        }

        public ICommandResult Put(UpdateBookCommand command)
        {

            var result = (CommandResult)_updateHandler.Handle(command);
            return result;
        }


    }
}
