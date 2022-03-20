using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.MovieOperations.Commands.Create;
using WebApi.Application.MovieOperations.Commands.Delete;
using WebApi.Application.MovieOperations.Commands.Update;
using WebApi.Application.MovieOperations.Queries.Get;
using WebApi.Application.MovieOperations.Queries.GetDetails;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class MovieController:ControllerBase
    {

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public MovieController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get()
        {
            GetMoviesQuery query=new (_context,_mapper);
            
            var movies=query.Handle();
            
            return Ok(movies);
        }
        [HttpGet("{id}")]
        public IActionResult GetDetails(int id)
        {
            GetMovieDetailsQuery query=new(_context,_mapper);
            query.MovieId=id;

            GetMovieDetailsQueryValidator validator=new();
            validator.ValidateAndThrow(query);

            var movie=query.Handle();
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMovieModel model)
        {
            CreateMovieCommand cmd = new(_context, _mapper);
            cmd.Model=model;
            CreateMovieCommandValidator validator = new();
            validator.ValidateAndThrow(cmd);

            cmd.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] UpdateMovieModel model)
        {
            UpdateMovieCommand cmd=new(_context,_mapper);
            cmd.MovieId=id;
            cmd.Model=model;
            UpdateMovieCommandValidator validator=new();
            validator.ValidateAndThrow(cmd);

            cmd.Handle();

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteMovieCommand cmd=new(_context);
            cmd.MovieId=id;

            DeleteMovieCommandValidator validator=new();
            validator.ValidateAndThrow(cmd);

            cmd.Handle();
            return Ok();

        }
        
    }
}