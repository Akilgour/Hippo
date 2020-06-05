using AutoMapper;
using Hippologamus.Shared.DTO;
using Hippologamus.Server.Models;
using Hippologamus.Server.Profiles.PerfLogCollectionResponceProfileMapper;

namespace Hippologamus.Server.Profiles
{
    public class ErrorLogCollectionProfile : Profile
    {
        public ErrorLogCollectionProfile()
        {
            CreateMap<ErrorLogCollectionResponce, ErrorLogPagedList>()
                .ForMember(dest => dest.ErrorLogs, opt => opt.MapFrom(src => src.Value))
                 .ForMember(dest => dest.ShowPerviousPageButton, opt => opt.MapFrom(src => SetShowPerviousPageButton.Resolve(src.Pagination.CurrentPage)))
                 .ForMember(dest => dest.ShowNextPageButton, opt => opt.MapFrom(src => SetShowNextPageButton.Resolve(src.Pagination)))
                 .ForMember(dest => dest.ShowFirstPageButton, opt => opt.MapFrom(src => SetShowFirstPageButton.Resolve(src.Pagination)))
                 .ForMember(dest => dest.ShowSecondPageButton, opt => opt.MapFrom(src => SetShowSecondPageButton.Resolve(src.Pagination)))
                 .ForMember(dest => dest.ShowPagePlusOneButton, opt => opt.MapFrom(src => SetShowPagePlusOneButton.Resolve(src.Pagination)))
                 .ForMember(dest => dest.ShowSecondEllipsis, opt => opt.MapFrom(src => SetShowSecondEllipsis.Resolve(src.Pagination)))
                 .ForMember(dest => dest.PaginationCurrentPagePlusOne, opt => opt.MapFrom(src => SetPaginationCurrentPagePlusOne.Resolve(src.Pagination)))
                 .ForMember(dest => dest.PaginationCurrentPageMinusOne, opt => opt.MapFrom(src => SetPaginationCurrentPageMinusOne.Resolve(src.Pagination)));

            CreateMap<ErrorLogCollection, ErrorLogList>();
        }
    }
}