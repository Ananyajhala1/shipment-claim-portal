using ClaimsAPI.Models;
using ClaimsAPI.Service.ClaimDocumentService;
using ClaimsAPI.Service.CompanyTypeService;
using ClaimsAPI.Service.DocumentTypeService;
using ClaimsAPI.Service.PermissionService;
using ClaimsAPI.Service.RolesService;
using ClaimsAPI.Service.UserInfoService;
using ClaimsAPI.Service.TemplatesService;
using ClaimsAPI.Service.LoginService;
using ClaimsAPI.Service.claim;
using ClaimsAPI.Service.claimEmail;
using ClaimsAPI.Service.claimSettings;
using ClaimsAPI.Service.company;
using ClaimsAPI.Service.location;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security;
using Microsoft.AspNetCore.Cors;
using ClaimsAPI.Service.UserCredentialService;
using Microsoft.Extensions.Azure;
using System.Text.Json.Serialization;
using ClaimsAPI.Middleware;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:3000") // enter the url of frontend in black string :)
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Add JWT Authentication support to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
}
);

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
builder.Services.AddTransient<ICompanyTypeService, CompanyTypeService>();
builder.Services.AddTransient<IDocumentTypeService, DocumentTypeService>();
builder.Services.AddTransient<IRolesService, RolesService>();
builder.Services.AddTransient<IPermissionService, PermissionService>();
builder.Services.AddTransient<IPermissionRoleService, PermissionRoleService>();
builder.Services.AddTransient<IClaimDocumentService, ClaimDocumentService>();
builder.Services.AddScoped<IUserInfoService, UserInfoService>();
builder.Services.AddScoped<ITemplateService, TemplatesService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddTransient<IClaimEmail, ClaimEmailService>();
builder.Services.AddTransient<IClaim, ClaimService>();
builder.Services.AddTransient<IClaimSettings, ClaimSettingService>();
builder.Services.AddTransient<ICompany, CompanyService>();
builder.Services.AddTransient<ILocation, LocationService>();
builder.Services.AddTransient<IUserCredentialService, UserCredentialService>();
builder.Services.AddScoped<RequestTokenInfo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1"));
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<TokenInfoMiddleware>();
app.MapControllers();

app.Run();