using AutoMapper;
using Hippologamus.Server.Models;
using Hippologamus.Server.Profiles.DetailLogCommentProfileMapper;
using Hippologamus.Server.Profiles.Shared;
using Hippologamus.Shared.DTO;

namespace Hippologamus.Server.Profiles
{
    public class DetailLogCommentProfile : Profile
    {
        public DetailLogCommentProfile()
        {
            CreateMap<DetailLogCommentEdit, DetailLogCommentCreate>();
            CreateMap<DetailLogCommentCollection, DetailLogCommentList>()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => DateTimeDisplay.Resolve(src.CreateOn)))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => DateTimeDisplay.Resolve(src.UpdatedOn)))
                .ForMember(dest => dest.OpenStateDisplay, opt => opt.MapFrom(src => OpenStateDisplay.Resolve(src.OpenState)));
            CreateMap<DetailLogCommentDetails, DetailLogCommentEdit>();
        }
    }
}