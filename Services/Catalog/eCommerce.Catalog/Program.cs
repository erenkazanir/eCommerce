using eCommerce.Catalog.Services.CategoryServices;
using eCommerce.Catalog.Services.ProductDetailServices;
using eCommerce.Catalog.Services.ProductImageServices;
using eCommerce.Catalog.Services.ProductServices;
using eCommerce.Catalog.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.MapOpenApi();
    //app.UseSwaggerUI(options => {
    //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "eCommerce.Catalog v1");
    //});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
