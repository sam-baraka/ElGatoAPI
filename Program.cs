using ElGatoAPI.Models;
using ElGatoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen();
builder.Services.Configure<CatDatabaseSettings>(
    builder.Configuration.GetSection("CatsDatabase"));
builder.Services.Configure<CatApiSettings>(
    builder.Configuration.GetSection("CatAPI"));

builder.Services.AddSingleton<BreedsService>();

builder.Services.AddSingleton<ImagesService>();

builder.Services.AddSingleton<PostsService>();

builder.Services.AddSingleton<ApiService>();
// Json serializer settings
builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();



