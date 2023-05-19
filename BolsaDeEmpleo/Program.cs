using BolsaDeEmpleo;
using BolsaDeEmpleo.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//servicio para relacionar la clase dbcontext con la cadena de conexion y el motor de db
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//servicio del mapeo de objetos e indicamos la clase que realiza el mapeo
builder.Services.AddAutoMapper(typeof(MappingConfig));

//servicio con alcance de crearse una vez por solicitud y luego se destruyen
//builder.Services.AddScoped<IVillaRepositorio, VillaRepositorio>();

//builder.Services.AddScoped<INumeroVillaRepositorio, NumeroVillaRepositorio>();

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

app.Run();
