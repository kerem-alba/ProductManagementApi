using ProductManagementApi.Models;
using ProductManagementApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/prodcuts", () =>
{
    var fileService = new FileService();
    var products = fileService.ReadProducts();
    return Results.Ok(products);
});

app.MapPost("/products", (ProductDto newProductDto) =>
{
    var fileService = new FileService();
    var products = fileService.ReadProducts();

    int newId = products.Any() ? products.Max(p => p.Id) + 1 : 1;

    var newProduct = new Product
    {
        Id = newId,
        Name = newProductDto.Name,
        Price = newProductDto.Price,
        Category = newProductDto.Category
    };

    products.Add(newProduct);
    fileService.WriteProducts(products);

    return Results.Created($"/products/{newId}", newProduct);
});

app.MapPut("/products/{id}", (int id, ProductDto newProductDto) =>
{
    var fileService = new FileService();
    var products = fileService.ReadProducts();

    var existingProduct = products.FirstOrDefault(p => p.Id == id);
    if (existingProduct is null)
    {
        return Results.NotFound($"Product with ID {id} was not found.");
    }

    existingProduct.Name = newProductDto.Name;
    existingProduct.Price = newProductDto.Price;
    existingProduct.Category = newProductDto.Category;

    fileService.WriteProducts(products);

    return Results.Ok(existingProduct);
});

app.MapDelete("/products/{id}", (int id) =>
{
    var fileService = new FileService();
    var products = fileService.ReadProducts();

    var productToDelete = products.FirstOrDefault(p => p.Id == id);
    if (productToDelete is null)
    {
        return Results.NotFound($"Product with ID {id} was not found.");
    }

    products.Remove(productToDelete);
    fileService.WriteProducts(products);

    return Results.Ok($"Product with ID {id} has been deleted.");
});



app.Run();

