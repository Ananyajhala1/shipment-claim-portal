using ClaimsAPI.Models;
using ClaimsAPI.Service.ClaimDocumentService;
using ClaimsAPI.Service.CompanyTypeService;
using ClaimsAPI.Service.DocumentTypeService;
using ClaimsAPI.Service.PermissionService;
using ClaimsAPI.Service.RolesService;
using ClaimsAPI.Service.UserInfoService;
using ClaimsAPI.Service.TemplatesService;
using ClaimsAPI.Service.LoginService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security;

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
builder.Services.AddTransient<ICompanyTypeService, CompanyTypeService>();
builder.Services.AddTransient<IDocumentTypeService, DocumentTypeService>();
builder.Services.AddTransient<IRolesService, RolesService>();
builder.Services.AddTransient<IPermissionService, PermissionService>();
builder.Services.AddTransient<IPermissionRoleService, PermissionRoleService>();
builder.Services.AddTransient<IClaimDocumentService, ClaimDocumentService>();
builder.Services.AddScoped<IUserInfoService, UserInfoService>();
builder.Services.AddScoped<ITemplateService, TemplatesService>();
builder.Services.AddScoped<ILoginService, LoginService>();


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