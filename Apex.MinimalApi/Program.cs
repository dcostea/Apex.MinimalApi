// add services configuration

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.ScanApexDependencies();
builder.Services.ScanApexEndpoints();

// add services

var app = builder.Build();

app.MapApexEndpoints();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
