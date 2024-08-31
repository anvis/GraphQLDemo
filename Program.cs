using GraphQLAPIDemo;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using GraphQL;
using GraphQLAPIDemo.GraphQL;
using GraphiQl;
using GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

//https://github.com/graphql-dotnet/server/tree/master/src/Transports.AspNetCore

// https://graphql-dotnet.github.io/docs/migrations/migration3/

// https://binodmahto.medium.com/graphql-with-asp-net-core-api-making-your-api-smart-50b27e9577e5

// Add services to the container.



builder.Services.AddControllers()
    .AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//builder.Services.AddDbContext<BlogDBContext>(item => item.UseSqlServer
//                               ("Server=ANVIRYZEN\\SQLEXPRESS;Database=BlogDB;Trusted_Connection=True;"));

builder.Services.AddSingleton<BlogDBContext>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<BlogDBContext>();
    optionsBuilder.UseSqlServer("Server=ANVIRYZEN\\SQLEXPRESS;Database=BlogDB;Trusted_Connection=True;");
    return new BlogDBContext(optionsBuilder.Options);
});



builder.Services.AddSingleton<IArticleRepository, ArticleRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ArticleGraphQLQuery>();
builder.Services.AddSingleton<ArticleGraphQLType>();
builder.Services.AddSingleton<ArticleGraphQLSchema>();
builder.Services.AddSingleton<ISchema ,ArticleGraphQLSchema>();

builder.Services.AddGraphQL(builder => builder
    .AddSystemTextJson()
    .AddAutoSchema<ArticleGraphQLSchema>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseGraphiQl("/graphql");
app.UseGraphQL<ISchema>();

//optional
//app.UseGraphQLPlayground(new GraphQL.Server.Ui.Playground.GraphqlPlaygroundOptions());

app.UseAuthorization();

app.MapControllers();

app.Run();
