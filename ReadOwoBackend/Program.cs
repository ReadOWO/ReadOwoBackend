using Microsoft.EntityFrameworkCore;
using ReadOwoBackend.Publishing.Domain.Models;
using ReadOwoBackend.Publishing.Domain.Repositories;
using ReadOwoBackend.Publishing.Domain.Services;
using ReadOwoBackend.Publishing.Persistence.Repositories;
using ReadOwoBackend.Publishing.Services;
using ReadOwoBackend.ReadOwo.Domain.Repositories;
using ReadOwoBackend.ReadOwo.Domain.Services;
using ReadOwoBackend.ReadOwo.Mapping;
using ReadOwoBackend.ReadOwo.Persistence.Repositories;
using ReadOwoBackend.ReadOwo.Services;
using ReadOwoBackend.Shared.Persistence.Contexts;
using ReadOwoBackend.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
//Saga and Saga Status
builder.Services.AddScoped<ISagaStatusRepository, SagaStatusRepository>();
builder.Services.AddScoped<ISagaStatusService, SagaStatusService>();
builder.Services.AddScoped<ISagaRepository, SagaRepository>();
builder.Services.AddScoped<ISagaService, SagaService>();
//Language
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
//Genre
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//Book and Book status
builder.Services.AddScoped<IBookStatusRepository, BookStatusRepository>();
builder.Services.AddScoped<IBookStatusService, BookStatusService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IChaptersRepository, ChaptersRepository>();
builder.Services.AddScoped<IChaptersService, ChaptersService>();

//bookGenre
builder.Services.AddScoped<IBookGenreRepository, BookGenreRepository>();
builder.Services.AddScoped<IBookGenreService, BookGenreService>();

// AutoMapper COnfiguration
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));

var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
