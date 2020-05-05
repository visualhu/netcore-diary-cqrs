using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Diary.CQRS.CommandHandlers;
using NetCore.Diary.CQRS.Commands;

namespace NetCore.Diary.CQRS.Utils
{
    // public class CommandHandlerFactory : ICommandHandlerFactory
    // {
    //     public ICommandHandler<T> GetHandler<T>() where T : Command
    //     {
    //         var handlers = GetHandlerTypes<T>().ToList();
    //         
    //         // var commandHandler = handlers.Select(h=>(ICommandHandler<T>)ObjectFactory.Get)
    //     }
    //
    //
    //     public IEnumerable<Type> GetHandlerTypes<T>() where T:Command
    //     {
    //         var handlers = typeof(ICommandHandler<>).Assembly.GetExportedTypes()
    //             .Where(x => x.GetInterfaces().Any(a =>
    //                 a.IsGenericType && a.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
    //             .Where(h => h.GetInterfaces().Any(i => i.GetGenericArguments().Any(j => j == typeof(T)))).ToList();
    //         return handlers;
    //     }
    // }
}