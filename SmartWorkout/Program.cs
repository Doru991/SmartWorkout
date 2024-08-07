using SmartWorkout.Components;
using SmartWorkout.DBAccess;
using SmartWorkout.DBAccess.Repository;
using SmartWorkout.DBAccess.Entities;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<IGenericRepository<User>>(serviceProvider => new GenericRepository<User>(new SmartWorkoutContext()));
builder.Services.AddScoped<IGenericRepository<Exercise>>(serviceProvider => new GenericRepository<Exercise>(new SmartWorkoutContext()));
builder.Services.AddScoped<IGenericRepository<Workout>>(serviceProvider => new GenericRepository<Workout>(new SmartWorkoutContext()));
builder.Services.AddScoped<IGenericRepository<ExerciseLog>>(serviceProvider => new GenericRepository<ExerciseLog>(new SmartWorkoutContext()));
builder.Services.AddDbContext<SmartWorkoutContext>();
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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
