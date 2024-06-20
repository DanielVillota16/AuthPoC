using AuthPoC.IdentityServer;
using IdentityServer4.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddIdentityServer(options =>
{
    options.UserInteraction = new UserInteractionOptions()
    {
        LogoutUrl = "/account/logout",
        LoginUrl = "/account/login",
        LoginReturnUrlParameter = "returnUrl"
    };
})
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiResources(Config.ApiResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddTestUsers(Config.Users)
    .AddDeveloperSigningCredential();

builder.Services.AddAuthentication("Bearer")
    .AddIdentityServerAuthentication(options =>
    {
        options.Authority = "https://localhost:7021";
        options.RequireHttpsMetadata = false;
        options.ApiName = "myApi";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.MapControllers();
app.Run();
