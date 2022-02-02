using System.Collections.Generic;

namespace ReactBoard.Domain.Common
{
    public interface IPaginationResult<T>
    {
        int CurrentPage { get; set; }

        int TotalPages { get; set; }

        IEnumerable<T> Entities { get; set; }
    }
}
