using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Shared.Commands
{
    public interface ICommandHandler<T> : ICommand
    {
        ICommandResult Handle(T command);
    }
}
