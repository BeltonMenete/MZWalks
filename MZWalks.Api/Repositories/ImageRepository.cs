using MZWalks.Api.Data;

namespace MZWalks.Api.Repositories;

public class ImageRepository
{
    private readonly Context _context;

    public ImageRepository(Context context)
    {
        _context = context;
    }
}