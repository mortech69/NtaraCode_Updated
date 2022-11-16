using NtaraCode.Services;
using NtaraCode.Services.EFCore;

#region Program
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Inject TeamService and Resolve
builder.Services.AddTransient<ITeamService, TeamService>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
#endregion

/// <summary>
/// IWebHostEnviroment Initialization
/// Import Environment to Seed the Database
/// </summary>
/// 
#region IWebService
var enviroment = app.Environment;

if (enviroment != null)
{ 
    TeamSeeder.Init(enviroment);
}
#endregion

#region apps
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
#endregion
