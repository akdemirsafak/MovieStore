using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

using WebApi.Application.DirectorOperations.Commands.Create;
using WebApi.Application.DirectorOperations.Commands.Delete;
using WebApi.Application.DirectorOperations.Commands.Update;
using WebApi.Application.DirectorOperations.Queries.Get;
using WebApi.Application.DirectorOperations.Queries.GetDetails;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController:ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public DirectorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get()
        {
            GetDirectorsQuery query = new(_context, _mapper);
            var directors = query.Handle();

            return Ok(directors);
        }


        [HttpGet("{id}")]
        public IActionResult GetDetails(int id)
        {
            GetDirectorDetailsQuery query = new(_context, _mapper);
            query.DirectorId = id;

            GetDirectorDetailsQueryValidator validator = new();
            validator.ValidateAndThrow(query);

            var director = query.Handle();
            return Ok(director);
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateDirectorModel newDirector)
        {
            CreateDirectorCommand cmd = new(_context, _mapper);
            cmd.Model = newDirector;

            CreateDirectorCommandValidator validator = new();
            validator.ValidateAndThrow(cmd);
            cmd.Handle();

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateDirectorModel updateDirector)
        {
            UpdateDirectorCommand cmd = new(_context);
            cmd.Model = updateDirector;
            cmd.DirectorId = id;

            UpdateDirectorCommandValidator validator = new();
            validator.ValidateAndThrow(cmd);

            cmd.Handle();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteDirectorCommand cmd = new(_context);
            cmd.DirectorId = id;

            DeleteDirectorCommandValidator validator = new();
            validator.ValidateAndThrow(cmd);

            cmd.Handle();
            return Ok();
        }





    }
}