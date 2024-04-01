using Microsoft.EntityFrameworkCore;
using TruckPlan.Data;
using TruckPlan.Data.Repositories;
using TruckPlan.Service.Integrations;
using TruckPlan.Service.Mappings;
using TruckPlan.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TruckPlanContext>(options =>
    options
    .UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString"),
      b => b.MigrationsAssembly(typeof(TruckPlanContext).Assembly.FullName)));

builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddScoped<IGoogleLocationServices, GoogleLocationServices>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<ITripPlanRepository, TripPlanRepository>();
builder.Services.AddScoped<ITruckPlanService, TruckPlanService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
});

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TruckPlanContext>();
    db.Database.Migrate();
}
app.Run();
