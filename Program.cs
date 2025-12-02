using GroupProject.Components;
using GroupProject.Services;

var builder = WebApplication.CreateBuilder(args);

// add our services to the DI container
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// register our custom services as singletons so state persists
builder.Services.AddSingleton<RecipeService>();
builder.Services.AddSingleton<AuthService>();
builder.Services.AddSingleton<CommentService>();

var app = builder.Build();

// configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
