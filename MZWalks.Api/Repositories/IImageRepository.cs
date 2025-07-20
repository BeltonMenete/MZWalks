using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Repositories;

public interface IImageRepository
{
    Task<Image> Upload(Image image);
}