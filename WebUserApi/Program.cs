using System.Text.Json.Serialization;
using WebUserApi.Helpers;
using WebUserApi.Services;

var builder = WebApplication.CreateBuilder( args );

var services = builder.Services;
var env = builder.Environment;

services.AddDbContext<DataContext>();
services.AddCors();
services.AddControllers().AddJsonOptions( x =>
{
    x.JsonSerializerOptions.Converters.Add( new JsonStringEnumConverter() );
    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
} );
services.AddAutoMapper( AppDomain.CurrentDomain.GetAssemblies() );

services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.UseCors( x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
