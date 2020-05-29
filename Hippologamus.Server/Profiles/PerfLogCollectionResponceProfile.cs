using AutoMapper;
using Hippologamus.DTO.DTO;
using Hippologamus.Server.Models;
using Hippologamus.Server.Profiles.PerfLogCollectionResponceProfileMapper;
using Hippologamus.Server.Profiles.Shared;

namespace Hippologamus.Server.Profiles
{
    public class PerfLogCollectionResponceProfile : Profile
    {
        public PerfLogCollectionResponceProfile()
        {
            CreateMap<PerfLogCollectionResponce, PerfLogPagedList>()
                 .ForMember(dest => dest.PerfLogs, opt => opt.MapFrom(src => src.Value))
                 .ForMember(dest => dest.ShowPerviousPageButton, opt => opt.MapFrom(src => SetShowPerviousPageButton.Resolve(src.Pagination.CurrentPage)))
                 .ForMember(dest => dest.ShowNextPageButton, opt => opt.MapFrom(src => SetShowNextPageButton.Resolve(src.Pagination)))
                 .ForMember(dest => dest.ShowFirstPageButton, opt => opt.MapFrom(src => SetShowFirstPageButton.Resolve(src.Pagination)))
                 .ForMember(dest => dest.ShowSecondPageButton, opt => opt.MapFrom(src => SetShowSecondPageButton.Resolve(src.Pagination)))
                 .ForMember(dest => dest.ShowPagePlusOneButton, opt => opt.MapFrom(src => SetShowPagePlusOneButton.Resolve(src.Pagination)))
                 .ForMember(dest => dest.ShowSecondEllipsis, opt => opt.MapFrom(src => SetShowSecondEllipsis.Resolve(src.Pagination)))
                 .ForMember(dest => dest.PaginationCurrentPagePlusOne, opt => opt.MapFrom(src => SetPaginationCurrentPagePlusOne.Resolve(src.Pagination)))
                 .ForMember(dest => dest.PaginationCurrentPageMinusOne, opt => opt.MapFrom(src => SetPaginationCurrentPageMinusOne.Resolve(src.Pagination)));

            CreateMap<PerfLogCollection, PerfLogList>()
                 .ForMember(dest => dest.TimeStamp, opt => opt.MapFrom(src => DateTimeDisplay.Resolve(src.TimeStamp)))
                 .ForMember(dest => dest.ElapsedMilliseconds, opt => opt.MapFrom(src => ElapsedMillisecondsDisplay.Resolve(src.ElapsedMilliseconds)));

            CreateMap<RootLink, Links>();
        }
    }
}