using Microsoft.EntityFrameworkCore;
using Movies.Presentation.Handlers;
using Subhub.Application;
using Subhub.Infrastructure;
using Subhub.Presentation.Modules;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//REGISTER DBCONTEXT AS A SERVICE 
//SETS UP THE CONNECTION TO THE SQLITE DATABASE using connection string
builder.Services.AddDbContext<SubscriptionsDbContext>(optionsAction => {
    optionsAction.UseSqlite(builder.Configuration.GetConnectionString(name:"DbConnectionString"));
});

builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy", policyBuilder => {
        policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});
builder.Services.AddApplication();

builder.Services.AddExceptionHandler<ExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(_ => { });
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.AddSubscriptionsEndpoints();

// Configure static file serving
app.UseStaticFiles();

app.Run();
