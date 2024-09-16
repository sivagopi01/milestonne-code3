using ASP.NET_core_web_api_Milestone_.Data;
using Microsoft.EntityFrameworkCore;
using ASP.NET_core_web_api_Milestone_.Repository;
using ASP.NET_core_web_api_Milestone_.Repository.ASP.NET_core_web_api_Milestone_.Models.ResolutionsRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TicketContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("MongoDB:ConnectionString")));
builder.Services.AddScoped<IResolutionsRepository, ResolutionRepository>();
builder.Services.AddScoped<ICommentsRepository,CommentsRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

