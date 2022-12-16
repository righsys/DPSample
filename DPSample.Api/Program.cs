using DPSample.Api.Services;
using DPSample.Infrastructure.DbContexts;
using DPSample.Infrastructure.Repositories.CommandRepositories;
using DPSample.Infrastructure.Repositories.QueryRepositories;
using DPSample.Services.Contracts.CommansRepositories;
using DPSample.Services.Contracts.QueryRepositories;
using DPSample.Services.Queries.GetAllUsers;
using DPSample.Services.ServiceImplementations;
using DPSample.Services.ServiceInterfaces;
using DPSample.SharedCore;
using DPSample.SharedCore.Interfaces;
using DPSample.SharedServices.Behaviours;
using DPSample.SharedServices.Interfaces;
using DPSample.Utilities.DateTimeHelper;
using DPSample.Utilities.Security;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//
// Using actual database
//
builder.Services.AddDbContext<CommandDbContext>(
    options => options
        .UseSqlServer(builder.Configuration.GetConnectionString("DPSampleDBConnection"))
        .EnableDetailedErrors());
//
//
//
var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme=JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    var Key = Encoding.UTF8.GetBytes(config["JWT:Key"]);
    var encryptionkey = Encoding.UTF8.GetBytes(config["JWT:EnKey"]);
    o.SaveToken = true;
    o.RequireHttpsMetadata = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        RequireSignedTokens = true,
        RequireExpirationTime = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = config["JWT:Issuer"],
        ValidAudience = config["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Key),
        TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey)
    };
    o.Events = new JwtBearerEvents() 
    {
        OnAuthenticationFailed = context =>
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
            logger.LogError("Authentication failed.", context.Exception);
            return Task.CompletedTask;
        },
        OnTokenValidated = context =>
        {
            var tokenValidatorService = context.HttpContext.RequestServices.GetRequiredService<ITokenValidatorService>();
            return tokenValidatorService.ValidateAsync(context);
        },
    };
});


//
//
//
builder.Services.AddScoped<CommandDbContext>();
builder.Services.AddScoped<QueryDbContext>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IDateTimeHelper, DateTimeHelper>();
builder.Services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
builder.Services.AddScoped<ICurrentApplicationServices, CurrentApplicationServices>();
builder.Services.AddScoped<ISecurityServices, SecurityServices>();
builder.Services.AddScoped<ITokenStoreService, TokenStoreService>();
builder.Services.AddScoped<ITokenValidatorService, TokenValidatorService>();

//
// Services
//
builder.Services.AddScoped<IUserQueryRepository, UserQueryRepository>();
builder.Services.AddScoped<IUserRoleQueryRepository, UserRoleQueryRepository>();
builder.Services.AddScoped<IUserTokenQueryRepository, UserTokenQueryRepository>();
builder.Services.AddScoped<IUserCommandRepository, UserCommandRepository>();
builder.Services.AddScoped<IUserRoleCommandRepository, UserRoleCommandRepository>();
builder.Services.AddScoped<IUserTokenCommandRepository, UserTokenCommandRepository>();
//
// Add serilog
//
builder.Services.AddSingleton(Log.Logger);
var _logger = new LoggerConfiguration()
    .WriteTo
    .File("D:\\DPSampleLog\\Logs\\alllogs-.log", rollingInterval: RollingInterval.Day)
    .WriteTo
    .File("D:\\DPSampleLog\\Logs\\warninganduplogs-.log", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning)
    .CreateLogger();
builder.Logging.AddSerilog(_logger);

//
//
//
builder.Services.AddMediatR(typeof(GetAllUsersDetailQuery).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

// Add services to the container.

//builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    g => {
        //g.SwaggerDoc("", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "DP Sample" });
        g.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
        {
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Description = "Please enter into field the word 'Bearer' following by space and JWT",
            Name = "Authorization",
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
        });
        g.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
            }
        });
    }
);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
