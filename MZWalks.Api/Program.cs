using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MZWalks.Api.Data;
using MZWalks.Api.Repositories;
using Scalar.AspNetCore;

// MZ Walks Configs
var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
var issuerSigningKey = builder.Configuration["Jwt:Key"];
var validIssuer = builder.Configuration["Jwt:Issuer"];
var validAudience = builder.Configuration["Jwt:Audience"];


builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connString));
builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IWalkRepository, WalkRepository>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options
        .TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerSigningKey)),
        ValidateIssuerSigningKey = true,
        ValidIssuer = validIssuer,
        ValidAudience = validAudience,
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options => options.WithTheme(ScalarTheme.DeepSpace)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.RestSharp)
    );
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();