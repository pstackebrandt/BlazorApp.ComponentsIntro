using BlazorApp.ComponentsIntro.Components;

// Blazor Server application
// ==============================================
// This app runs completely on the server. UI interactions are synchronized between browser and server via SignalR connections.
// We don't need another project to run the app.

// Create Blazor Web Application
// -----------------------------
var webAppBuilder = WebApplication.CreateBuilder(args);

// Register server-side interactive components
webAppBuilder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); 

var app = webAppBuilder.Build();

// Configure the HTTP request pipeline
// -------------------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

// Map resources
// ------------------------
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // Map Razor components

app.Run();