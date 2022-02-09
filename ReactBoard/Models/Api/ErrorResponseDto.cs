using System.Collections.Generic;

namespace ReactBoard.API.Models.Api
{
    public sealed class ErrorResponseDto
    {
        public List<string> Errors { get; set; }
    }
}
