using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacPlaygroundable;
using AutofacPlaygroundable.Commands;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

var builder = new ContainerBuilder();

//соединение IServiceCollection и ContainerBuilder() 
builder.Populate(serviceCollection);

builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());


//можно передавать значения по умолчанию при регистрации
//builder.Register(c => new TodayWriter().As<IConfigReader>();

//или так
//builder.RegisterType<ConfigReader>().As<IConfigReader>().WithParameter("configSectionName", "sectionName");

// WriteDate();
//
// void WriteDate()
// {
//     {
//         //если сервис зареган - создаст, если нет-нет
//         //var service = scope.ResolveOptional<IService>();
//
//         var writer = Container.Resolve<TodayWriter>();
//         writer.WriteDate();
//         Console.WriteLine(writer.Number);
//
//         writer.Rase(5);
//
//         var second = Container.Resolve<TodayWriter>();
//         Console.WriteLine(second.Number);
//     }
// }


var container = builder.Build();

var handler = container.Resolve<CommandHandler>();
await handler.HandleAsync( new SimpleCommand
{
    Now = DateTime.Now
});