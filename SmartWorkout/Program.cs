using SmartWorkout.Components;
using SmartWorkout.DBAccess;
using SmartWorkout.DBAccess.Repository;
using SmartWorkout.DBAccess.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<IGenericRepository<User>>(serviceProvider => new UserRepository(new SmartWorkoutContext()));
builder.Services.AddScoped<IGenericRepository<Exercise>>(serviceProvider => new GenericRepository<Exercise>(new SmartWorkoutContext()));
builder.Services.AddScoped<IGenericRepository<Workout>>(serviceProvider => new GenericRepository<Workout>(new SmartWorkoutContext()));
builder.Services.AddScoped<IGenericRepository<ExerciseLog>>(serviceProvider => new GenericRepository<ExerciseLog>(new SmartWorkoutContext()));
builder.Services.AddScoped<IGenericRepository<UserRole>>(serviceProvider => new GenericRepository<UserRole>(new SmartWorkoutContext()));
builder.Services.AddDbContext<SmartWorkoutContext>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.Name = "auth_token";
    options.LoginPath = "/login";
    options.Cookie.MaxAge = TimeSpan.FromMinutes(120);
    options.AccessDeniedPath = "/denied";
});
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
