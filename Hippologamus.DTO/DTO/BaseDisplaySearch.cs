﻿namespace Hippologamus.DTO.DTO
{
    public abstract class BaseDisplaySearch
    {
        private const int maxPageSize = 3;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}