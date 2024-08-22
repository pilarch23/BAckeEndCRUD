using BackEndCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using BackEndCRUD.Services.Implementation;
using BackEndCRUD.Services.Contract;

using AutoMapper;
using BackEndCRUD.DTOs;
using BackEndCRUD.Utilities;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Server=LAPTOP-TLGBFTHO\\SQLEXPRESS01;DataBase=MOVIES_DB_EJEMPLO;Trusted_Connection=true;TrustServerCertificate=true

builder.Services.AddDbContext<MoviesDbEjemploContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

builder.Services.AddScoped<IDirectorService, DirectorService>();
builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


#region API REST REQUEST 
app.MapGet("/director/list", async (
    IDirectorService _directorService,
    IMapper _mapper
    ) =>
{
    var DirectorList = await _directorService.GetList();
    var DirectorListDTO = _mapper.Map<List<DirectorDTO>>(DirectorList);

    if (DirectorListDTO.Count > 0)
        return Results.Ok(DirectorListDTO);
    else
        return Results.NotFound();
});

app.MapPost("/director/save", async (
    DirectorDTO modelo,
    IDirectorService _directorService,
    IMapper _mapper
    ) => {
        var _director = _mapper.Map<Director>(modelo);
        var _directorCreate = await _directorService.Add(_director);

        if (_directorCreate.IdDirector != 0)
            return Results.Ok(_mapper.Map<DirectorDTO>(_directorCreate));
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
    });

app.MapPut("/director/update/{idDirector}", async (
    int idDirector,
    DirectorDTO modelo,
    IDirectorService _directorService,
    IMapper _mapper
    ) => {
        var _found = await _directorService.GetDirector(idDirector);

        if (_found is null)
            return Results.NotFound();

        var _director = _mapper.Map<Director>(modelo);

        _found.DirectorName = _director.DirectorName;
        _found.Age = _director.Age;
        _found.Active = _director.Active;

        var response = await _directorService.UpdateDirector(_found);

        if (response)
            return Results.Ok(_mapper.Map<DirectorDTO>(_found));
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
    });

app.MapDelete("/director/delete/{idDirector}", async (
    int idDirector,
    IDirectorService _directorService
    ) => {
        var _found = await _directorService.GetDirector(idDirector);

        if (_found is null)
            return Results.NotFound();

        var response = await _directorService.DeleteDirector(_found);

        if (response)
            return Results.Ok();
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
    });

app.MapGet("/movie/list", async (
    IMovieService _movieService,
    IMapper _mapper
    ) =>
{
    var MovieList = await _movieService.GetList();
    var MovieListDTO = _mapper.Map<List<MovieDTO>>(MovieList);

    if (MovieListDTO.Count > 0)
        return Results.Ok(MovieListDTO);
    else
        return Results.NotFound();
});


app.MapPost("/movie/save", async (
    MovieDTO modelo,
    IMovieService _movieService,
    IMapper _mapper
    ) => {
        var _movie = _mapper.Map<Movie>(modelo);
        var _movieCreate = await _movieService.Add(_movie);

        if (_movieCreate.IdMovies != 0)
            return Results.Ok(_mapper.Map<MovieDTO>(_movieCreate));
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
    });


app.MapPut("/movie/update/{idMovie}", async (
    int idMovie,
    MovieDTO modelo,
    IMovieService _movieService,
    IMapper _mapper
    ) => {
        var _found = await _movieService.Get(idMovie);

        if (_found is null)
            return Results.NotFound();

        var _movie = _mapper.Map<Movie>(modelo);

        _found.MovieName = _movie.MovieName;
        _found.Gender = _movie.Gender;
        _found.Duration = _movie.Duration;
        _found.DirectorKey = _movie.DirectorKey;

        var response = await _movieService.Update(_found);

        if (response)
            return Results.Ok(_mapper.Map<Movie>(_found));
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
    });


app.MapDelete("/movie/delete/{idMovie}", async (
    int idMovie,
    IMovieService _movieService
    ) => {
        var _found = await _movieService.Get(idMovie);

        if (_found is null)
            return Results.NotFound();

        var response = await _movieService.Delete(_found);

        if (response)
            return Results.Ok();
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
    });
#endregion

app.UseCors("NewPolicy");

app.Run();

