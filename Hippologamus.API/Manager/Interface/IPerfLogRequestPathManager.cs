﻿using Hippologamus.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Manager.Interface
{
    public interface IPerfLogRequestPathManager
    {
        Task<List<PerfLogRequestPathCollection>> GetByAssembly(string perfLogAssembly);
    }
}