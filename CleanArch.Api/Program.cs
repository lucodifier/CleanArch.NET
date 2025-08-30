using CleanArch.Application.Contracts;
using CleanArch.Data.Repositories;
using CleanArch.Application.Products.Handlers;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProductHandler).Assembly));

// Configure repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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

// Redirecionar a raiz para o Swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

// Abrir o navegador automaticamente no Swagger
if (app.Environment.IsDevelopment())
{
    var url = "http://localhost:5005/swagger";
    try
    {
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }
    catch
    {
        // Ignora erros ao abrir o navegador
    }
}

app.Run();

