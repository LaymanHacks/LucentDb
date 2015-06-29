using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;

namespace LucentDb.Web
{
    public static class PagedResultHelper
    {
        public static PagedResult<T> CreatePagedResult<T>(int requestedPage, int pageSize, int totalCount, ICollection<T> data)
        {
            var totalPages = (int) Math.Ceiling((double) totalCount/pageSize);
            var result = new PagedResult<T>
            {
                TotalCount = totalCount,
                PageCount = totalPages,
                PageSize = pageSize,
                CurrentPage = requestedPage,
                Results = data
            };
            return result;
        }
    }
}