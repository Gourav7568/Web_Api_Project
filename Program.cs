using MyApiProject.Services;
var builder = WebApplication.CreateBuilder(args);

// ✅ Register services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Register ProductService in DI container
builder.Services.AddScoped<IProductService, ProductService>(); // Add this line

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
    