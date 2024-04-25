using FisherYates.Algorithm;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddScoped<IShufflerService, ShufflerService>();
var app = builder.Build();
app.UseRouting();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}");
app.Run();