// configure services

var builder = WebApplication.CreateBuilder();

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCustomDependencies();
builder.Services.ScanCustomEndpoints();

// add services

var app = builder.Build();

app.CustomMap();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
