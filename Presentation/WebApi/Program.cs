using Application.Abstract;
using Application.Features.CQRS.Handlers.AboutHandlers;
using Persistence.Context;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<DatabaseContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<DeleteAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<GetAboutQueryHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
