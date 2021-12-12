var builder = WebApplication.CreateBuilder();

// configure services
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
Endpoints.Scan(builder.Services);

var app = builder.Build();

// add services
Endpoints.Map(app);
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();

app.Logger.LogInformation("The app is started");
