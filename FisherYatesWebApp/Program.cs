using FisherYates.Algorithm;

var builder = WebApplication.CreateBuilder(args);
using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = factory.CreateLogger<Program>();
builder.Services.AddMvc();
builder.Services.AddScoped<IShufflerService, ShufflerService>();
var app = builder.Build();
app.UseRouting();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}");
app.Run();