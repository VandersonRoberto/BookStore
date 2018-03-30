using BookStore.Domain.Commands;
using BookStore.Domain.Entities;
using BookStore.Domain.Repositories;
using BookStore.Shared.Commands;
using BookStore.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Handlers
{
    public class UpdateBookHandler : IHandler<UpdateBookCommand>
    {

        private readonly IBookRepository _repository;


        public UpdateBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(UpdateBookCommand command)
        {
            //Fail Tast Validation 
            if (!command.Valid())
                return new CommandResult(false, "Falha ao gravar livro");

            var book = new Book(command.Title, command.Edition, command.Author, command.StockQuantity);
            book.Id = (Guid)command.Id;

            _repository.Update(book);

            return new CommandResult(true, "Livro gravado com sucesso");

        }
    }
}
