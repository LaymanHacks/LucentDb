using System;
using System.Collections.Generic;

namespace LucentDb.Web
{
    public class PagedResult<T>
    {
        public PagedResult(int requestedPage, int pageSize, int totalCount, ICollection<T> data)
        {
            var totalPages = (int) Math.Ceiling((double) totalCount/pageSize);
            TotalCount = totalCount;
            PageCount = totalPages;
            PageSize = pageSize;
            CurrentPage = requestedPage;
            Results = data;
        }

        public ICollection<T> Results { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}