﻿using Hippologamus.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hippologamus.API.Service.Service.Interface
{
    public interface IDetailLogCommentService
    {
        Task CreateDetailLogComent(DetailLogComment detailLogComment);
        Task<List<DetailLogComment>> GetByDetailLogId(int detailLogId);
        Task<DetailLogComment> GetByDetailLogCommentsId(int detailLogCommentsId);
        Task Update(DetailLogComment detailLogComment);
        Task<bool> Any(int id);
    }
}