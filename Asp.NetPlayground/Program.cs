using System.Security.Claims;
using Asp.NetPlayground;
using Asp.NetPlayground.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Endpoints;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc.Filters;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//         .AddCookie(options =>
//         {
//             options.LoginPath         = "/login";
//             options.Cookie.Name       = "brabras-api";
//             options.ExpireTimeSpan    = TimeSpan.FromMinutes(10);
//             options.SlidingExpiration = true;
//
//             options.Events = new CookieAuthenticationEvents
//             {
//                 OnRedirectToLogin = redirectContext =>
//                 {
//                     redirectContext.HttpContext.Response.StatusCode = 401;
//                     return Task.CompletedTask;
//                 }
//             };
//         });
// services.AddAuthorization();
//
// var configuration = builder.Configuration;
//
// var redisConnectionString = configuration.GetConnectionString("Redis");
// var redis                 = ConnectionMultiplexer.Connect(redisConnectionString);
//
// services.AddDataProtection()
//         .SetApplicationName("brabras-api")
//         .PersistKeysToStackExchangeRedis(redis, "DataProtectionKeys");
//
// services.AddStackExchangeRedisCache(options =>
// {
//     options.Configuration = redisConnectionString;
//     options.InstanceName  = "brabras-api";
// });

services.AddMvcCore(options => //
{
    options.Filters.Add<DbSessionAttributeActionFilter>();
});

services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.UseCors();

var people = new List<Person>
{
    Person.Create("tom@gmail.com", "12345"),
    Person.Create("bob@gmail.com", "55555")
};

app.MapPost("/login", async (string? returnUrl, HttpContext context) =>
{
    var form = context.Request.Form;
    if (!form.ContainsKey("email") || !form.ContainsKey("password"))
        return Results.BadRequest("Email и/или пароль не установлены");

    string email    = form["email"];
    string password = form["password"];

    Person? person = people.FirstOrDefault(p => p.Login == email && p.Password == password);
    // если пользователь не найден, отправляем статусный код 401
    if (person is null) return Results.Unauthorized();

    var claims = new List<Claim> { new(ClaimTypes.Name, person.Login) };
    // создаем объект ClaimsIdentity
    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
    // установка аутентификационных куки
    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
    return Results.Redirect(returnUrl ?? "/");
});

app.MapPost("/check", (HttpContext context) =>
{
    var endpoint             = context.GetEndpoint();
    var endpointRootMetadata = endpoint!.Metadata.GetMetadata<IRouteDiagnosticsMetadata>();
    if (endpointRootMetadata is not null)
    {
        Console.WriteLine(endpointRootMetadata);
    }
});

app.Map("/", [Authorize]() => "Hello World!");

app.MapGet("/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
               string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)));

app.Run();