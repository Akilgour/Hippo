using AutoMapper;
using System;

namespace Hippologamus.API.Manager
{
    public abstract class BaseManager
    {
        protected readonly IMapper _mapper;

        protected BaseManager(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}