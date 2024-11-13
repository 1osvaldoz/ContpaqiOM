using ContpaqiOM.OAuth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("OAuthClient", client =>
{
    client.BaseAddress = new Uri("https://dev-otrwvksw.us.auth0.com");  
});
builder.Services.AddTransient<OAuthService>(sp =>
{
    var clientId = "epBAbL2TSzmaJ9BL7nSGkL0MT3a42vfY";
    var clientSecret = "lkNo6fC-NVSJYy5rGLiNHqs4z4AwhwamD1TrRTqE_CD3vxvrWKlAuZBecbeSdygB";
    var authUrl = "https://dev-otrwvksw.us.auth0.com/authorize?audience=https://invoice-transformation.cti.com";
    var accessTokenUrl = "https://dev-otrwvksw.us.auth0.com/oauth/token";

    return new OAuthService(sp.GetRequiredService<HttpClient>(), clientId, clientSecret, authUrl, accessTokenUrl);
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://dev-otrwvksw.us.auth0.com";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false
        };
        options.Events = new JwtBearerEvents
        {
            OnChallenge = async context =>
            {
                context.HandleResponse();
                context.Response.StatusCode = 401;
                var json = JsonSerializer.Serialize(new { status = 401, title = "Unauthorized", detail = "Access token is expired or invalid"  });
                await context.Response.WriteAsync(json);
            }
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

app.MapControllers().RequireAuthorization();

app.Run();
