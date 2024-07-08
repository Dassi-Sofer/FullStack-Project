global using Microsoft.EntityFrameworkCore;
using WebProject.BL;
using WebProject.DAL;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;
//using WebProject.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using WebProject;
using Microsoft.AspNetCore.Hosting;
using WebProject.Middleware;
//using WebProject.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUserService, UserServise>();
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IPresent, PresentService>();
builder.Services.AddScoped<IBucketItemService, BucketItemService>();
builder.Services.AddScoped<IBucketService,BucketService>(); 
builder.Services.AddScoped<IRuffleService, RuffleService>();

builder.Services.AddScoped<IDonorDal, DonorDal>();
builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IPresentDal, PresentDal>();
builder.Services.AddScoped<IBItemDal, BitemDal>();
builder.Services.AddScoped<IBucketDal, BucketDal>();
builder.Services.AddScoped<IRuffleDal, RuffleDal>();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
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
                    Array.Empty<string>()
                }
            });

    c.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200",
                                "development web site")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
builder.Services.AddDbContext<PresentContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("PresentContext")));


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = "http://localhost:7024/",
        ValidAudience = "http://localhost:4200/",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();
var app = builder.Build();
app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;
app.MapControllers();
app.UseCors("CorsPolicy");
app.UseWhen(context => !context.Request.Path.StartsWithSegments("/api/User/Register") && !context.Request.Path.StartsWithSegments("/api/Login"),
    orderApp =>
    {
        orderApp.Use(async (context, next) =>
        {
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var AuthorizationHeader = context.Request.Headers["Authorization"].ToString();
                if (AuthorizationHeader.StartsWith("Bearer "))
                {
                    context.Request.Headers["Authorization"] = AuthorizationHeader.Substring("Bearer ".Length);

                }
            }
            await next();
        });
        orderApp.UseMiddleware<MiddlewareClass>();
    });

app.Run();
