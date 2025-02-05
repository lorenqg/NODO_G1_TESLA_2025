using System.Net;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.Models;
using TeslaACDC.Data.IRepository;
using TeslaACDC.Data.Repository;
namespace TeslaACDC.Business.Services;

public class ArtistService : IArtistService
{
  private readonly NikolaContext _context;
  private IArtistRepository<int, Artist> _artistRepository;

  public ArtistService(NikolaContext context)
  {
    _context = context;
    _artistRepository = new ArtistRepository<int, Artist>(_context);
  }

    public async Task<BaseMessage<Artist>> GetArtists()
    {
        var list = await _artistRepository.ArtistList();
        return list.Any() ?  BuildResponse(list, "", HttpStatusCode.OK) : 
            BuildResponse(list, "", HttpStatusCode.NotFound);
    }

    public async Task<BaseMessage<Artist>> AddArtist(Artist artist)
    {
       await _artistRepository.AddAsync(artist);
       if (artist == null) {
            return BuildResponse(new (), "", HttpStatusCode.BadRequest);
        }

        return BuildResponse(new List<Artist> { artist }, "Success", HttpStatusCode.OK);
    }

    public async Task<BaseMessage<Artist>> FindById(int id)
    {
       var artist = await _artistRepository.FindAsync(id);
       if (artist == null) {
            return BuildResponse(new (), "", HttpStatusCode.BadRequest);
        }

        return BuildResponse(new List<Artist> { artist }, "Success", HttpStatusCode.OK);
    }

    public async Task<BaseMessage<Artist>> UpdateArtist(int id, Artist artist)
    {
        var res = await _artistRepository.UpdateAsync(id, artist);
        if (res == null) {
            return BuildResponse(new (), "", HttpStatusCode.BadRequest);
        }

        return BuildResponse(new List<Artist> { res }, "Success", HttpStatusCode.OK);
    }

    public async Task<BaseMessage<Artist>> DeleteById(int id)
    {
        var artist = await _artistRepository.DeleteAsync(id);
        if (artist == null) {
            return BuildResponse(new (), "", HttpStatusCode.BadRequest);
        }

        return BuildResponse(new List<Artist> { artist }, "Success", HttpStatusCode.OK);
    }

    private BaseMessage<Artist> BuildResponse(List<Artist> list, string message = "", HttpStatusCode status = HttpStatusCode.OK, int totalElements = 0)
    {
        return new BaseMessage<Artist>(){
            Message = message,
            StatusCode = status,
            TotalElements = totalElements > 0 ? totalElements : list.Count,
            ResponseElements = list
        };
    }
}