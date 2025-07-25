﻿namespace MZWalks.Api.Contracts.Response;

public class RegionResponse
{
    public string Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? RegionImageURL { get; set; }
}