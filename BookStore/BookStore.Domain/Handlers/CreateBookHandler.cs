using BookStore.Domain.Commands;
using BookStore.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Shared.Commands;
using BookStore.Domain.Repositories;
using BookStore.Domain.Entities;

namespace BookStore.Domain.Handlers
{
    public class CreateBookHandler : IHandler<CreateBookCommand>
    {

        private readonly IBookRepository _repository;


        public CreateBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateBookCommand command)
        {
            //Fail Tast Validation 
            if (!command.Valid())
                return new CommandResult(false, "Falha ao gravar livro");
            
            if (_repository.CheckTitleExists(command.Title))
                return new CommandResult(false, "Título livro já em uso");

            var book = new Book(command.Title, command.Edition,command.Author, command.StockQuantity);

            _repository.Create(book);

            return new CommandResult(true, "Livro gravado com sucesso");

        }
    }
}
