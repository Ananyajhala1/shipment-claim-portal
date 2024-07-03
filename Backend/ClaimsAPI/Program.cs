using ClaimsAPI.Models;
using ClaimsAPI.Service.claim;
using ClaimsAPI.Service.claimEmail;
using ClaimsAPI.Service.claimSettings;
using ClaimsAPI.Service.company;
using ClaimsAPI.Service.location;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShipmentClaimsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StudyConnection")));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

    };
});
builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddTransient<IClaimEmail, ClaimEmailService>();
builder.Services.AddTransient<IClaim, ClaimService>();
builder.Services.AddTransient<IClaimSettings, ClaimSettingService>();
builder.Services.AddTransient<ICompany, CompanyService>();
builder.Services.AddTransient<ILocation, LocationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();