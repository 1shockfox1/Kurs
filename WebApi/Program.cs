using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApi.Model;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<GgContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<SumzakazService, SumzakazService>();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Simple Test API", Version = "v1" });
    options.AddSecurityDefinition("JWT_OR_COOKIE", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference()
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id=JwtBearerDefaults.AuthenticationScheme
                    }
                },
                new string[]{}
            }
        });
});



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = AuthOptoins.ISSUER,
        ValidateAudience = true,
        ValidAudience = AuthOptoins.AUDIENCE,
        ValidateLifetime = true,
        IssuerSigningKey = AuthOptoins.GetSymmetricSecurityKey(),
        ValidateIssuerSigningKey = true


    };
});


var app = builder.Build();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapPost("/login", async (Person user, GgContext gg) =>
{
    Person? person = await gg.Persons!.FirstOrDefaultAsync(p => p.Email == user.Email);
    string Password = AuthOptoins.GetHash(user.Password);
    if (person is null) return Results.Unauthorized();
    if (person.Password != Password) return Results.Unauthorized();
    var claims = new List<Claim> { new Claim(ClaimTypes.Email, user.Email) };
    var jwt = new JwtSecurityToken(
        issuer: AuthOptoins.ISSUER,
        audience: AuthOptoins.AUDIENCE,
        claims: claims,
        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),

        signingCredentials: new SigningCredentials(AuthOptoins.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        
    var encoderJWT = new JwtSecurityTokenHandler().WriteToken(jwt);

    var response = new
    {
        assess_token = encoderJWT,
        username = person.Email
    };
    return Results.Json(response);
});

app.MapPost("/register", async (Person user, GgContext gg) =>
{
    user.Password = AuthOptoins.GetHash(user.Password);
    gg.Persons.Add(user);
    await gg.SaveChangesAsync();
    Person createdUser = gg.Persons.FirstOrDefault(p => p.Email == user.Email)!;
    return Results.Ok(createdUser);
});

var gg = app.Services.CreateScope().ServiceProvider.GetRequiredService<GgContext>();
//SeedData.SeedDatabase(gg);


app.Run();


public class AuthOptoins
{
    public const string ISSUER = "MyAuthServer";
    public const string AUDIENCE = "MyAuthClient";
    const string key = "mysupersecret_secretsecretkey!123";
    public static SymmetricSecurityKey GetSymmetricSecurityKey()=>new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

    public static string GetHash(string plaintext)
    {
        var sha = new SHA1Managed();
        byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(plaintext));
        return Convert.ToBase64String(hash);
    }
}