using System.Collections.Generic;

namespace oracle.api.Dtos
{
    public class PagedResultsDto<T>
    {
        public int TotalRecords { get; set; }
        public IEnumerable<T> Results { get; set; }
    }
}