using Nicesleeping.DataAccess.Interfaces.Categories;
using Nicesleeping.DataAccess.Repositories.Categories;
using Nicesleeping.Services.Interfaces.Categories;
using Nicesleeping.Services.Interfaces.Common;
using Nicesleeping.Services.Services.Categories;
using Nicesleeping.Services.Services.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();  
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IPaginator,Paginator>();

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
