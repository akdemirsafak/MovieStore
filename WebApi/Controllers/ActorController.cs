using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorOperations.Commands.Create;
using WebApi.Application.ActorOperations.Commands.Delete;
using WebApi.Application.ActorOperations.Commands.Update;
using WebApi.Application.ActorOperations.Queries.Get;
using WebApi.Application.ActorOperations.Queries.GetDetails;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ActorController:ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult Get(){
            GetActorsQuery query=new(_context,_mapper);
            var actors=query.Handle();

            return Ok(actors);
        }


        [HttpGet("{id}")]
        public IActionResult GetDetails(int id)
        {
            GetActorDetailsQuery query = new(_context, _mapper);
            query.ActorId=id;

            GetActorDetailsQueryValidator validator=new();
            validator.ValidateAndThrow(query);

            var actor = query.Handle();
            return Ok(actor);
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateActorModel newActor)
        {
            CreateActorCommand cmd=new(_context,_mapper);
            cmd.Model=newActor;

            CreateActorCommandValidator validator=new();
            validator.ValidateAndThrow(cmd);
            cmd.Handle();

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] UpdateActorModel updateActor)
        {
            UpdateActorCommand cmd = new(_context);
            cmd.Model = updateActor;
            cmd.ActorId=id;

            UpdateActorCommandValidator validator = new();
            validator.ValidateAndThrow(cmd);

            cmd.Handle();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteActorCommand cmd = new(_context);
            cmd.ActorId = id;

            DeleteActorCommandValidator validator = new();
            validator.ValidateAndThrow(cmd);

            cmd.Handle();            
            return Ok();
        }





    }
}