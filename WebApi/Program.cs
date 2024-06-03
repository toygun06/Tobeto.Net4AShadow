using Business.Abstracts;
using Business.Concretes;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using System.Reflection;
using Business;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using TokenOptions = Core.Utilities.JWT.TokenOptions;
using Core.Utilities.Encryption;
using Core.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddBusinessService();
builder.Services.AddDataAccessService();
builder.Services.AddCoreServices(tokenOptions);
//Assembly



builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        //JWT Configuration
        //TODO: Gerekli alanları appsettings.json'dan okuyarak burada token optionsları belirle.

        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });


//Singleton-Scoped-Transien -> Lifetime
//Singleton => Üretilen ba??ml?l?k uygulama aç?k oldu?u sürece tek bir kere newlenir.
//Her enjeksiyonda o instance kullan?l?r.

//Scoped => (API iste?i) ?stek ba??na 1 instance olu?turur.
//Transient => Her ad?mda (her talepte) yeni 1 instance.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionMiddlewareExtensions();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
