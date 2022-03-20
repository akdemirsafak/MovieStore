using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.CustomerOperations.Commands.Delete;
using WebApi.Application.CustomerOperations.Commands.Update;
using WebApi.Application.CustomerOperations.Commands.Create;
using WebApi.Application.CustomerOperations.Queries.Get;
using WebApi.Application.CustomerOperations.Queries.GetDetails;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController:ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(IMovieStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        [HttpGet]
        public IActionResult Get()
        {
            GetCustomersQuery query=new(_context,_mapper);
            var customers=query.Handle();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public IActionResult GetDetails(int id)
        {
            GetCustomerDetailsQuery query = new(_context, _mapper);
            query.CustomerId=id;
            var customer = query.Handle();
            return Ok(customer);
            
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomerModel newCustomer)
        {
            CreateCustomerCommand cmd = new(_context, _mapper);
            cmd.Model=newCustomer;
            
            CreateCustomerCommandValidator validator=new();
            validator.ValidateAndThrow(cmd);
            
            cmd.Handle();
            return Ok();

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] UpdateCustomerModel updateCustomer)
        {
            UpdateCustomerCommand cmd = new(_context);
            cmd.Model = updateCustomer;
            cmd.CustomerId=id;

            UpdateCustomerCommandValidator validator = new();
            validator.ValidateAndThrow(cmd);
            cmd.Handle();

            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteCustomerCommand cmd= new(_context);
            cmd.CustomerId=id;
            
            DeleteCustomerCommandValidator validator= new();
            validator.ValidateAndThrow(cmd);

            cmd.Handle();
            return Ok();
        }

        
    }
}