using Biblioteca.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

//log para depuração (estava tendo problemas com as requisições).
//app.Use(async (context, next) =>
//{
//    Console.WriteLine($"Requisição: {context.Request.Method} {context.Request.Path}");
//    await next.Invoke();
//    Console.WriteLine($"Resposta: {context.Response.StatusCode}");
//});


app.UseAuthorization();

app.MapControllers();

app.Run();
