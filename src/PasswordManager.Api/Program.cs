using PasswordManager.Common.Models;
using PasswordManager.Common.Extensions;
using PasswordManager.Persistence;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Api.Helpers;
using PasswordManager.Common.Helpers;
using System.Reflection;
using Microsoft.OpenApi.Models;
using PasswordManager.Common.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add Database
builder.Services.AddDbContext<PasswordManagerRepository>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PasswordManagerDb"));
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCommonServices();
builder.Services.AddCustomServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<AuthorizeCheckOperationFilter>();

    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var jwtSetting = new JwtSetting();
builder.Configuration.Bind("JwtSetting", jwtSetting);
builder.Services.AddJwtServices(jwtSetting);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

HttpContextHelper.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
