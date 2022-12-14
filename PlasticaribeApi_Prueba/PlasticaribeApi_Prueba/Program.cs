using Microsoft.EntityFrameworkCore;
using PlasticaribeApi_Prueba.Data;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<dataContext>(options =>

//CONEXI?N A BASE DE DATOS PlasticaribeBDD. 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: SqlOptions =>
        {
            SqlOptions.EnableRetryOnFailure();
        }
    );

});

//HABILITAR CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,


        builder =>
        {
            builder.WithOrigins("http://192.168.0.153:4600", "http://192.168.0.85:4700", "http://192.168.0.153:4700", "http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();

        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//USAR CORS 
app.UseCors(myAllowSpecificOrigins);


app.UseStaticFiles();

/*app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
    RequestPath = new PathString("/wwwroot")
});*/


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
