using Microsoft.EntityFrameworkCore;
using TeamlanceAPI.Data;
using WebApi.Helpers;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

{
    var services = builder.Services;
    services.AddCors();
    services.AddControllers();

    // configure strongly typed settings object

    services.Configure<WebApi.Helpers.AppSettings>(builder.Configuration.GetSection("AppSettings"));

    // configure DI for application services
    services.AddScoped<IUserService, UserService>();
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ProjectsAPIDbContext>(options => options.UseInMemoryDatabase("ProjectsDb"));
builder.Services.AddDbContext<ProjectsAPIDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectsApiConnectionString"))
);


var app = builder.Build();
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // custom jwt auth middleware
    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();

app.Run();
