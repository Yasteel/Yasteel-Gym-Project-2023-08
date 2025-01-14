﻿namespace Models.DTOs
{
    public class BlobResponseDto : ApiResponse
    {
        public string? Uri { get; set; }

        public string? Name { get; set; }

        public string? ContentType { get; set; }

        public Stream? Content { get; set; }
    }
}
