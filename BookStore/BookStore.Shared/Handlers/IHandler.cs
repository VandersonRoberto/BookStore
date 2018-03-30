using BookStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
