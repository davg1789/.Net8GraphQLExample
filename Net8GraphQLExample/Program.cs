using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Net8GraphQLExample.Data.Context;
using Net8GraphQLExample.Data.Repository;
using Net8GraphQLExample.Domain.Interfaces.Repository;
using Net8GraphQLExample.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GraphQLExampleDbContext>(option => option.UseSqlite(@"Data Source=States.db"));
builder.Services.AddTransient<IStateRepository, StateRepository>();
builder.Services.AddTransient<ICityRepository, CityRepository>();

builder.Services.AddScoped<DataSchema>();

builder.Services.AddGraphQL().AddSystemTextJson().AddGraphTypes(typeof(DataSchema), ServiceLifetime.Scoped);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseGraphQL<DataSchema>();
app.UseGraphQLPlayground(options: new GraphQL.Server.Ui.Playground.PlaygroundOptions());

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL<DataSchema>();

    
    endpoints.MapGraphQLPlayground();
});

app.Run();
