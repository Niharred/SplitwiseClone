// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SplitwiseCLI;
using SplitwiseCLI.Commands;
using SplitwiseCLI.Controllers;
using SplitwiseCLI.repositories;
using SplitwiseCLI.Services;

Console.WriteLine("Hello, World!");




var services = new ServiceCollection();

services.AddDbContext<Context>(options => { options.UseSqlServer("Server=SURUKK;Database=SplitwiseCloneCLI;Trusted_Connection=True;TrustServerCertificate=True"); });


services.AddScoped<IUserService, UserService>();
services.AddScoped<IGroupService, GroupService>();
services.AddScoped<DbContext, Context>();

var serviceProvider = services.BuildServiceProvider();







CommandExecutor commandExecutor = new CommandExecutor();
commandExecutor.addCommands(new CreateCommand(new UserController(serviceProvider.GetRequiredService<IUserService>())));
commandExecutor.addCommands(new CreateGroup(new GroupController(serviceProvider.GetRequiredService<IGroupService>())));




while (true)
{

    Console.WriteLine("Enter input : ");
    string input = Console.ReadLine();
    Console.WriteLine(input);
    commandExecutor.Execute(input);
   
}

static void BuildConfig(IConfigurationBuilder builder)
{

    builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",optional:false, reloadOnChange:true);
}