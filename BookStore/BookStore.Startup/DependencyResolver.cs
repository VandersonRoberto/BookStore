using BookStore.Domain.Commands;
using BookStore.Domain.Handlers;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Data.Repositories;
using BookStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace BookStore.Startup
{
    public  class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IBookRepository, BookRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<CreateBookCommand,CreateBookCommand>(new HierarchicalLifetimeManager());
            container.RegisterType<CreateBookHandler, CreateBookHandler>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommandResult, CommandResult>(new HierarchicalLifetimeManager());

        }
    }
}
