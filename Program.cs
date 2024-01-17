using System.Reflection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Serilog;
using SQLite;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();


//Log.Information("aguanteee river");


//estooo agregueeeee y el paquete capaz no funcaaaaaa
builder.Services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders(); // Limpia otros proveedores de logging
            loggingBuilder.AddSerilog(); // Agrega Serilog como proveedor
        });


builder.Services.AddScoped<UserService>();

/*
builder.Services.AddScoped<SQLiteConnection>(_ =>
{
    // Configura y retorna la instancia de SQLiteConnection
    string localDb = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "localDb");
    return new SQLiteConnection(localDb);
});
*/




//builder.Services.Configure<DbOptions>(builder.Configuration.GetSection("DbOptions"));
//builder.Services.Configure<DbOptions>(builder.Configuration.GetSection("ConnectionStrings"));

 // Registra la clase DbOptions para inyección de dependencias
builder.Services.AddScoped(provider => provider.GetRequiredService<IOptionsSnapshot<DbOptions>>().Value);
// Configuración de DbOptions desde appsettings.json
builder.Services.Configure<DbOptions>(builder.Configuration.GetSection("DbOptions"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
    });
    var xmlFilename = $"./Documentation.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


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
