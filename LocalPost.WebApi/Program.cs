using LocalPost.Application.Commands;
using LocalPost.Application.Queries;
using LocalPost.Infraestructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<LocalPostDbContext>(options =>
   options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<LocalPostDbContext>();
builder.Services.AddScoped<LocalPostDbService>();
// Add services to the container here.
builder.Services.AddScoped<AddPostHandler>();
builder.Services.AddScoped<DeletePostHandler>();
builder.Services.AddScoped<GetPostsHandler>();
builder.Services.AddScoped<GetPostHandler>();
builder.Services.AddScoped<GetPostsFilterHandler>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable services only if environment is Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();