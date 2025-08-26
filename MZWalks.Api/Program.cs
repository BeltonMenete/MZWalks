using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using MZWalks.Api.Data;
using MZWalks.Api.Middlewares;
using MZWalks.Api.Repositories;
using Scalar.AspNetCore;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Configuration
var validIssuer = builder.Configuration["Jwt:Issuer"];
var issuerSigningKey = builder.Configuration["Jwt:Key"];
var validAudience = builder.Configuration["Jwt:Audience"];
var dbConnectionString = builder.Configuration.GetConnectionString("DbConnection");
var authConnectionString = builder.Configuration.GetConnectionString("AuthConnection");

//  Add Logging
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("./Logs/MZWalks_logs.txt", rollingInterval: RollingInterval.Minute)
    .MinimumLevel.Information()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Services
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(dbConnectionString));
builder.Services.AddDbContext<AuthContext>(options => options.UseSqlServer(authConnectionString));

builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IWalkRepository, WalkRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IImageRepository, LocalImageRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("MZWalks")
    .AddEntityFrameworkStores<AuthContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerSigningKey)),
            ValidateIssuerSigningKey = true,
            ValidIssuer = validIssuer,
            ValidAudience = validAudience
        };
    });

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options => options
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.RestSharp));
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseMiddleware<GlobalExceptionHandler>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
});
app.MapControllers();
app.Run();