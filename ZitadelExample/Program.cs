using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
        .AddCookie()
        .AddOpenIdConnect(options =>
        {
            //OpenID Connect (OIDC) authentication middleware configuration
            options.Authority = "https://jedisadmin-hvypus.zitadel.cloud";
            options.ClientId = "251117166731024265@zitadel_basic";
            options.ClientSecret = "ZSno5pB7B6eaphyyCOUYCMowtUTMut7sypTdJmT5C4ve77l1LtlJoK2kOg8avhPM";
            options.ResponseType = "code";
            options.Scope.Add("openid");
            options.Scope.Add("profile");
            options.CallbackPath = "/signin-zitadel";
            options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.SaveTokens = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true
            };
        });

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
