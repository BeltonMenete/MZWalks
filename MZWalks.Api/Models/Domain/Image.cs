﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MZWalks.Api.Models.Domain;

public class Image
{
    public string Id { get; set; }
    [NotMapped]
    public IFormFile File { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Extension { get; set; }
    public long SizeInBytes { get; set; }
    public string Path { get; set; }
}