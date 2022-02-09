﻿namespace ReactBoard.ImageAPI.Domain.Models
{
    public sealed class ApiImageDto
    {
        public string Data { get; set; }

        public ApiImageMetadataDto Metadata { get; set; }
    }
}
