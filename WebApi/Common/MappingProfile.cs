using AutoMapper;
using WebApi.Application.ActorOperations.Commands.Create;
using WebApi.Application.ActorOperations.Queries.Get;
using WebApi.Application.ActorOperations.Queries.GetDetails;
using WebApi.Application.CustomerOperations.Commands.Create;
using WebApi.Application.CustomerOperations.Queries.Get;
using WebApi.Application.CustomerOperations.Queries.GetDetails;
using WebApi.Application.DirectorOperations.Commands.Create;
using WebApi.Application.DirectorOperations.Queries.Get;
using WebApi.Application.DirectorOperations.Queries.GetDetails;
using WebApi.Application.GenreOperations.Commands.Create;
using WebApi.Application.GenreOperations.Queries.Get;
using WebApi.Application.GenreOperations.Queries.GetDetails;
using WebApi.Application.MovieOperations.Commands.Create;
using WebApi.Application.MovieOperations.Queries.Get;
using WebApi.Application.MovieOperations.Queries.GetDetails;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //GENRE
            CreateMap<Genre, GenreDetailsViewModel>();
            CreateMap<Genre,GenreViewModel>();
            CreateMap<CreateGenreModel, Genre>();

            //MOVIE
            CreateMap<CreateMovieModel,Movie>();
            CreateMap<Movie, MovieDetailsViewModel>()
                .ForMember(dest => dest.Date, src => src.MapFrom(opt => opt.PublishDate.ToString("dd.MM.yyyy")))
                .ForMember(dest => dest.Genre, src => src.MapFrom(opt => opt.Genre.Name))
                .ForMember(dest => dest.Director, src => src.MapFrom(opt => opt.Director.Name + " " + opt.Director.LastName));
            CreateMap<Movie,MovieViewModel>()
                .ForMember(dest=>dest.Date,src=>src.MapFrom(opt=>opt.PublishDate.ToString("dd.MM.yyyy")))
                .ForMember(dest=>dest.Genre,src=>src.MapFrom(opt=>opt.Genre.Name))
                .ForMember(dest => dest.Director, src => src.MapFrom(opt => opt.Director.Name+" "+opt.Director.LastName));

            //ACTOR
            CreateMap<CreateActorModel, Actor>();
            CreateMap<Actor, ActorDetailsViewModel>();
            CreateMap<Actor, ActorViewModel>();

            //DIRECTOR
            CreateMap<CreateDirectorModel, Director>();
            CreateMap<Director, DirectorDetailsViewModel>();
            CreateMap<Director, DirectorViewModel>();

            //CUSTOMER
             CreateMap<CreateCustomerModel, Customer>();
            CreateMap<Customer, CustomerDetailsViewModel>();
             CreateMap<Customer, CustomerViewModel>();



        }
    }
}