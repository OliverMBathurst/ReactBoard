using System.Collections.Generic;

namespace ReactBoard.Domain.Common
{
    public sealed class PaginationResult<T> : IPaginationResult<T>
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<T> Entities { get; set; }
    }
}
