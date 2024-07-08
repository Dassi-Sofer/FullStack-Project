using AutoMapper;
using WebProject.DTO;
using WebProject.Models;

namespace WebProject
{ 
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<DonorDTO, Donor>().ReverseMap();
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //.ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
            //.ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //.ForMember(dest => dest.TypeOfDonation, opt => opt.Ignore())
            //.ForMember(dest => dest.DonationsList, opt => opt.Ignore());
            CreateMap<PresentDTO, Present>().ReverseMap();
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //.ForMember(dest => dest.CardPrice, opt => opt.MapFrom(src => src.CardPrice))
            //.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            //.ForMember(dest => dest.DonorId, opt => opt.MapFrom(src => src.DonorId))
            //.ForMember(dest => dest.Donor, opt => opt.MapFrom(src => src.DonorId.CompareTo(Ge));
            CreateMap<BucketDTO, Bucket>().ReverseMap();
            CreateMap<RaffleDTO, Raffle>().ReverseMap();
            CreateMap<BucketItemDTO, BucketItem>().ReverseMap();



        }
    }
}
