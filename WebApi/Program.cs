using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



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


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.Map("/login/{username}", (string username) =>
{
    var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
    var iwt = new JwtSecurityToken(issuer:AuthOptoins.ISSUER, audience:AuthOptoins.AUDIENCE,
        claims:claims,
        expires:DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
        signingCredentials: new SigningCredentials(AuthOptoins.GetSymmetricSecurityKey(),
        SecurityAlgorithms.HmacSha256));
    return new JwtSecurityTokenHandler().WriteToken(iwt);
});
app.MapControllers();

app.Run();


public class AuthOptoins
{
    public const string ISSUER = "MyAuthServer";
    public const string AUDIENCE = "MyAuthClient";
    const string key = "1qwertyuiop!123";
    public static SymmetricSecurityKey GetSymmetricSecurityKey()=>new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
}