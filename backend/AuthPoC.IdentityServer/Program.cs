using AuthPoC.IdentityServer;
using IdentityServer4.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

UserInteractionOptions UserInteraction = new()
{
    LogoutUrl = "/account/logout",
    LoginUrl = "/account/login",
    LoginReturnUrlParameter = "returnUrl"
};

builder.Services.AddIdentityServer(options => { options.UserInteraction = UserInteraction; })
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiResources(Config.ApiResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddTestUsers(Config.Users)
    .AddDeveloperSigningCredential();

// builder.Services.AddAuthentication("Bearer")
//     .AddIdentityServerAuthentication(options =>
//     {
//         options.Authority = "https://localhost:7021";
//         options.RequireHttpsMetadata = false;
//         options.ApiName = "myApi";
//     });

builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:7021";
        options.RequireHttpsMetadata = false;
        options.Audience = "myApi";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// app.UseRouting();
app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
