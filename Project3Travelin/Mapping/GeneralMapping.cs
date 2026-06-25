using AutoMapper;
using Project3Travelin.Dtos.CategoryDtos;
using Project3Travelin.Dtos.CommentDtos;
using Project3Travelin.Dtos.ReservationDtos;
using Project3Travelin.Dtos.TourDtos;
using Project3Travelin.Entities;

namespace Project3Travelin.Mapping
{
    public class GeneralMapping:Profile
    { 
        //ctor tab
        public GeneralMapping()
        {
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category,GetCategoryByIdDto>().ReverseMap();


            CreateMap<Tour,CreateTourDto>().ReverseMap();
            CreateMap<Tour,ResultTourDto>().ReverseMap();
            CreateMap<Tour,UpdateTourDto>().ReverseMap();
            CreateMap<Tour,GetTourByIdDto>().ReverseMap();


            CreateMap<Reservation, ResultReservationDto>().ReverseMap();
            CreateMap<Reservation, CreateReservationDto>().ReverseMap();

            CreateMap<Comment, ResultCommentDto>().ReverseMap();
            CreateMap<CreateCommentDto, Comment>().ReverseMap();
        }
    }
}
