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
            CreateMap<Genre, GenreDetailsViewModel>()
           .ForMember(dest => dest.Customers,
                 src => src.
                 MapFrom(opt => opt.GenreCustomers.Select(x => x.Customer.Name + " " + x.Customer.LastName))
            )
            .ForMember(dest => dest.HowMuchCustomerFav,
                 src => src.
                 MapFrom(opt => opt.GenreCustomers.Count())
            )
            .ForMember(dest => dest.GenreMovies,
                 src => src.
                 MapFrom(opt => opt.GenreMovies.Select(x => x.Name))
            );
            
            CreateMap<Genre,GenreViewModel>()
            .ForMember(dest => dest.Customers,
                 src => src.
                 MapFrom(opt => opt.GenreCustomers.Select(x => x.Customer.Name + " " + x.Customer.LastName))
            )
            .ForMember(dest => dest.GenreMovies,
                 src => src.
                 MapFrom(opt => opt.GenreMovies.Select(x => x.Name))
            );
            CreateMap<CreateGenreModel, Genre>();



            //MOVIE
            CreateMap<CreateMovieModel,Movie>();
            CreateMap<Movie, MovieDetailsViewModel>()
                .ForMember(dest => dest.Date, src => src.MapFrom(opt => opt.PublishDate.ToString("dd.MM.yyyy")))
                .ForMember(dest => dest.Genre, src => src.MapFrom(opt => opt.Genre.Name))
                .ForMember(dest => dest.Director, src => src.MapFrom(opt => opt.Director.Name + " " + opt.Director.LastName))
                .ForMember(dest => dest.MovieActors,
                    src => src.
                    MapFrom(opt => opt.MovieActors.Select(x => x.Actor.Name + " " + x.Actor.LastName))
                );

            CreateMap<Movie,MovieViewModel>()
                .ForMember(dest=>dest.Date,src=>src.MapFrom(opt=>opt.PublishDate.ToString("dd.MM.yyyy")))
                .ForMember(dest=>dest.Genre,src=>src.MapFrom(opt=>opt.Genre.Name))
                .ForMember(dest => dest.Director, src => src.MapFrom(opt => opt.Director.Name+" "+opt.Director.LastName))
                .ForMember(dest => dest.MovieActors,
                 src =>src.
                 MapFrom(opt=>opt.MovieActors.Select(x=>x.Actor.Name + " " + x.Actor.LastName))
                 );
            


            //ACTOR
            CreateMap<CreateActorModel, Actor>();
            CreateMap<Actor, ActorDetailsViewModel>()
                .ForMember(dest => dest.Movies,
                    src => src.
                    MapFrom(opt => opt.MovieActors.Select(x => x.Movie.Name))
                ); 
            
            CreateMap<Actor, ActorViewModel>()
              .ForMember(dest => dest.Movies,
                    src => src.
                    MapFrom(opt => opt.MovieActors.Select(x => x.Movie.Name))
                ); 

            //DIRECTOR
            CreateMap<CreateDirectorModel, Director>();
            CreateMap<Director, DirectorDetailsViewModel>()
            .ForMember(dest => dest.Movies,
                 src => src.
                 MapFrom(opt => opt.Movies.Select(x => x.Name))
                 );
            CreateMap<Director, DirectorViewModel>()
            .ForMember(dest => dest.Movies,
                 src => src.
                 MapFrom(opt => opt.Movies.Select(x=>x.Name))
                 );
            
            //CUSTOMER
            CreateMap<CreateCustomerModel, Customer>();
            CreateMap<Customer, CustomerDetailsViewModel>()
            .ForMember(dest => dest.FavGenres,
                src => src.
                MapFrom(opt => opt.CustomerGenres.Select(x => x.Genre.Name))
            );

            CreateMap<Customer, CustomerViewModel>()
            .ForMember(dest => dest.FavGenres,
                src => src.
                MapFrom(opt => opt.CustomerGenres.Select(x => x.Genre.Name))
            );
         
             
        
           


        }
    }
}