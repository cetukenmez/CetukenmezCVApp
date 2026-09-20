using CetukenmezCVApp.Data;
using CetukenmezCVApp.Models;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<CvProfile>(_ => CvData.Profile);

// The app sits behind an Apache reverse proxy on the Pi; trust its X-Forwarded-* headers.
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownIPNetworks.Clear();
    options.KnownProxies.Clear();
});

var app = builder.Build();

app.UseForwardedHeaders();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStatusCodePagesWithReExecute("/Home/Error", "?code={0}");

// Static assets are fingerprinted and served pre-compressed (br/gz) by MapStaticAssets;
// no ResponseCompression middleware needed (it conflicts with the pre-compressed responses).
app.MapStaticAssets();
app.UseRouting();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Stable download URL that survives CV file renames.
app.MapGet("/cv.pdf", (CvProfile profile) => Results.Redirect("/" + profile.CvFile));

// The 2022 CV was shared under this URL; keep old links working.
app.MapGet("/28072022cv.pdf", (CvProfile profile) => Results.Redirect("/" + profile.CvFile, permanent: true));

app.Run();
