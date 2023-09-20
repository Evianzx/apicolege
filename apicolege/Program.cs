using apicolege.Data;
using apicolege.Data.repositorio;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MySQLConfiguration = new MySQLConfiguration(builder.Configuration.GetConnectionString("MysqlConnection"));
builder.Services.AddSingleton(MySQLConfiguration);

builder.Services.AddSingleton(new MySqlConnection(builder.Configuration.GetConnectionString("MysqlConnection")));

builder.Services.AddScoped<IAsignaturaRepositorio, AsignaturaRepositorio>();
builder.Services.AddScoped<IDocenteRepositorio, DocenteRepositorio>();
builder.Services.AddScoped<IEstudianteRepositorio, EstudianteRepositorio>();



builder.Services.AddCors(option =>
{
    option.AddPolicy("NuevasPoliticas", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
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
app.UseCors("NuevasPoliticas");

app.UseAuthorization();

app.MapControllers();

app.Run();
