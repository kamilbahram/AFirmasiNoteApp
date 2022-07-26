using AFirmasi.MyNotes.DataAccess.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using AFirmasi.MyNotes.Business.Abstract;
using AFirmasi.MyNotes.Business;
using AFirmasi.MyNotes.DataAccess.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages();

builder.Services.AddDbContext<MyNotesDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("AFirmasi.MyNotes.WebapiServis")));

builder.Services.AddTransient<INoteService, NoteManeger>();
builder.Services.AddTransient<INoteRepository, NoteDal>();
builder.Services.AddTransient<ICategoryService, CategoryManeger>();
builder.Services.AddTransient<ICategoryRepository, CategoryDal>();


var app = builder.Build(); 


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

SeedDataBase.initialize(app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
