using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.Commands.Create;
using WebApi.Application.GenreOperations.Commands.Delete;
using WebApi.Application.GenreOperations.Commands.Update;
using WebApi.Application.GenreOperations.Queries.Get;
using WebApi.Application.GenreOperations.Queries.GetDetails;
using WebApi.DbOperations;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class GenreController : ControllerBase
{
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;
    public GenreController(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    

    [HttpGet]
    public IActionResult Get()
    {
        GetGenresQuery query=new GetGenresQuery(_context,_mapper);
        var genres=query.Handle();
        
        return Ok(genres);
    }
    [HttpGet("{id}")]
    public IActionResult GetDetails(int id)
    {
        GetGenreDetailsQuery query=new GetGenreDetailsQuery(_context,_mapper);
        query.GenreId=id;
        
        GetGenreDetailsQueryValidator validationRules=new GetGenreDetailsQueryValidator();
        validationRules.ValidateAndThrow(query);

         var genre=query.Handle();
         return Ok(genre);
    }


    [HttpPost]
    public IActionResult Create([FromBody] CreateGenreModel model)
    {
        CreateGenreCommand cmd=new(_context,_mapper);
        cmd.Model=model;

        CreateGenreCommandValidator validator=new();
        validator.ValidateAndThrow(cmd);

        cmd.Handle();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateGenreModel model)
    {
        UpdateGenreCommand cmd = new(_context);
        cmd.GenreId=id;
        cmd.Model = model;

        UpdateGenreCommandValidator validator = new();
        validator.ValidateAndThrow(cmd);

        cmd.Handle();
        return Ok();
    }




    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        DeleteGenreCommand cmd = new DeleteGenreCommand(_context);
        cmd.GenreId = id;

        DeleteGenreCommandValidator validationRules = new();
        validationRules.ValidateAndThrow(cmd);

        cmd.Handle();
        return Ok();
    }
}
