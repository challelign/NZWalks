﻿namespace NZWalks.API.Models.DTOs
{
    public class UpdateRegionsRequestDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
