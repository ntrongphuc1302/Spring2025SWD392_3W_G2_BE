using System.Reflection;
using System.Text;
using FluentValidation.AspNetCore;
using FluentValidation;
using MetroOne.Api.Middlewares;
using MetroOne.BLL.Services.Implementations;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DAL;
using MetroOne.DAL.Repositories.Implementations;
using MetroOne.DAL.Repositories.Interfaces;
using MetroOne.DAL.UnitOfWork;
using MetroOne.DTO.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


#region JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };

     //options.Events = new JwtBearerEvents
     //   {
     //       OnChallenge = context =>
     //       {
     //           // Skip the default behavior
     //           context.HandleResponse();
     //           context.Response.StatusCode = 401;
     //           context.Response.ContentType = "application/json";
     //           return context.Response.WriteAsync("{\"message\": \"You must be logged in to access this resource.\"}");
     //       },
     //       OnForbidden = context =>
     //       {
     //           context.Response.StatusCode = 403;
     //           context.Response.ContentType = "application/json";
     //           return context.Response.WriteAsync("{\"message\": \"You do not have permission to access this resource.\"}");
     //       }
     //   };
});
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("Users", new OpenApiInfo { Title = "User APIs", Version = "v1" });
    opt.SwaggerDoc("Auth", new OpenApiInfo { Title = "User APIs", Version = "v1" });
    opt.SwaggerDoc("Debug", new OpenApiInfo { Title = "Debug APIs", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.IncludeXmlComments(xmlPath);

    // Add JWT bearer to Swagger
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT Bearer token **_only_**",

        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    opt.AddSecurityDefinition("Bearer", securityScheme);

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, new string[] { } }
    });

});

builder.Services.AddAuthorization();

#endregion

#region CORS

//Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();
//Auth
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//User
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Location
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();

//Train
builder.Services.AddScoped<ITrainRepository, TrainRepository>();
builder.Services.AddScoped<ITrainService, TrainService>();

//Station
builder.Services.AddScoped<IStationRepository, StationRepository>();
builder.Services.AddScoped<IStationService, StationService>();

builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<ITripRepository, TripRepository>();

//Ticket
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();

//Route
builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<IRouteRepository, RouteRepository>();

//RouteLocation
builder.Services.AddScoped<IRouteLocationRepository, RouteLocationRepository>();
builder.Services.AddScoped<IRouteLocationService, RouteLocationService>();

//Payment
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

// Frontend Connection
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // React frontend
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

#endregion

#region Validators
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters(); 
builder.Services.AddValidatorsFromAssemblyContaining<MetroOne.Api.Validators.CreateStationRequestValidator>();
//builder.Services.AddValidatorsFromAssemblyContaining<MetroOne.Api.Validators.CreateTicketRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<MetroOne.Api.Validators.CreateTrainRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<MetroOne.Api.Validators.LoginRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<MetroOne.Api.Validators.RegisterRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<MetroOne.Api.Validators.UpdateStationRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<MetroOne.Api.Validators.UpdateUserRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<MetroOne.Api.Validators.UpdateTrainRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<MetroOne.Api.Validators.UpdateTicketRequestValidator>();
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


// Register the DbContext with the connection string
builder.Services.AddDbContext<MetroonedbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Setting up

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/Auth/swagger.json", "Auth API");
        options.SwaggerEndpoint("/swagger/Users/swagger.json", "User APIs");
        options.SwaggerEndpoint("/swagger/Debug/swagger.json", "Debug APIs");
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthentication(); // JWT must come before UseAuthorization

app.UseAuthorization();

app.MapControllers();

app.Run();
