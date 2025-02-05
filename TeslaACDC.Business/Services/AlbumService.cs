using System.Net;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.Models;
using TeslaACDC.Data.IRepository;
using TeslaACDC.Data.Repository;

namespace TeslaACDC.Business.Services;

public class AlbumService : IAlbumService
{
    private readonly NikolaContext _context;
    private IAlbumRepository<int, Album> _albumRepository;

    public AlbumService(NikolaContext context)
    {
        _context = context;
        _albumRepository = new AlbumRepository<int, Album>(_context);
    }

    public async Task<BaseMessage<Album>> GetAlbums()
    {
        var list = await _albumRepository.AlbumList();
        return list.Any() ?  BuildResponse(list, "", HttpStatusCode.OK) : 
            BuildResponse(list, "", HttpStatusCode.NotFound);
    }

    public async Task<BaseMessage<Album>> AddAlbum(Album album)
    {
        await _albumRepository.AddAsync(album);
        
        if (album == null) {
            return BuildResponse(new (), "", HttpStatusCode.BadRequest);
        }

        return BuildResponse(new List<Album> { album }, "Success", HttpStatusCode.OK);
    }

    public async Task<BaseMessage<Album>> FindById(int id)
    {
        var album = await _albumRepository.FindAsync(id);
        
        if (album == null) {
            return BuildResponse(new (), "", HttpStatusCode.BadRequest);
        }

        return BuildResponse(new List<Album> { album }, "Success", HttpStatusCode.OK);
    }

    public async Task<BaseMessage<Album>> DeleteById(int id)
    {
        var album = await _albumRepository.DeleteAsync(id);
        if (album == null) {
            return BuildResponse(new (), "", HttpStatusCode.BadRequest);
        }

        return BuildResponse(new List<Album> { album }, "Success", HttpStatusCode.OK);
    }

    public async Task<BaseMessage<Album>> UpdateAlbum(int id, Album album)
    {
        var res = await _albumRepository.UpdateAsync(id, album);
        if (res == null) {
            return BuildResponse(new (), "", HttpStatusCode.BadRequest);
        }

        return BuildResponse(new List<Album> { res }, "Success", HttpStatusCode.OK);
    }

    private BaseMessage<Album> BuildResponse(List<Album> list, string message = "", HttpStatusCode status = HttpStatusCode.OK, int totalElements = 0)
    {
        return new BaseMessage<Album>(){
            Message = message,
            StatusCode = status,
            TotalElements = totalElements > 0 ? totalElements : list.Count,
            ResponseElements = list
        };
    }
}
