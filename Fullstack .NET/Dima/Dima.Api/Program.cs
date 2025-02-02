using Dima.Api.Data;
using Dima.Api.Handlers;
using Dima.Core.Hanlders;
using Dima.Core.Model;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(n => n.FullName);
});
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

var app = builder.Build();

app.MapGet("/v1/categories", async (ICategoryHandler handler) =>
{
    var request = new GetAllCategoriesRequest
    {
        UserId = "teste@balta.io"
    };
    return await handler.GetAllAsync(request);
})
    .WithName("Categories: GetAll")
    .WithSummary("Busca todas as categorias de um usu�rio")
    .Produces<PagedResponse<List<Category>>>();

app.MapGet("/v1/categories/{id}", async (long id, ICategoryHandler handler) =>
{
    var request = new GetCategoryByIdRequest
    {
        Id = id,
    };
    return await handler.GetByIdAsync(request);
})
    .WithName("Categories: GetById")
    .WithSummary("Busca categoria por Id")
    .Produces<Response<Category?>>();

app.MapPost("/v1/categories", async (CreateCategoryRequest request, ICategoryHandler handler) => await handler.CreateAsync(request))
    .WithName("Categories: Create")
    .WithSummary("Cria uma nova categoria")
    .Produces<Response<Category?>>();

app.MapPut("/v1/categories/{id}", async (long id, UpdateCategoryRequest request, ICategoryHandler handler) => 
{
    request.Id = id;
    return await handler.UpdateAsync(request);
})
    .WithName("Categories: Update")
    .WithSummary("Atualiza uma categoria")
    .Produces<Response<Category?>>();


app.MapDelete("/v1/categories/{id}", async (long id, ICategoryHandler handler) => 
{
    var request = new DeleteCategoryRequest
    {
        Id = id,
    };
    return await handler.DeleteAsync(request);
})
    .WithName("Categories: Delete")
    .WithSummary("Deleta uma categoria")
    .Produces<Response<Category?>>();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();