using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using API.Data;
using API.Models;
using API.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Configurações do Swagger, se necessário
});

builder.Services.AddDbContext<APIRepository>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection")));


builder.Services.AddDbContext<UsuarioDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("API-API")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});



var app = builder.Build();

builder.Services.AddIdentity<UsuarioModel, IdentityRole>().AddUserStore<UserStore<UsuarioModel>>().AddRoleStore<RoleStore<IdentityRole>>().AddDefaultTokenProviders();

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddScoped<IUserStore<UsuarioModel>>(provider =>
{
    var dbContext = provider.GetRequiredService<UsuarioDbContext>();
    return new UserStore<UsuarioModel>(dbContext);
});



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

// Remove app.UseAuthorization() if not needed for your application

app.MapControllers();
app.UseAuthentication();

app.Run();
