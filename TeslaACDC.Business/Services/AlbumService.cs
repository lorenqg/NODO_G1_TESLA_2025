using System.Net;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.Models;
using TeslaACDC.Data.IRepository;

namespace TeslaACDC.Business.Services;

public class AlbumService : IAlbumService
{
    private IAlbumRepository<int, Album> _albumRepository;

    public AlbumService(IAlbumRepository<int, Album> albumRepository)
    {
       _albumRepository = albumRepository;
    }

    public async Task<BaseMessage<Album>> GetAlbums()
    {
        var list = await _albumRepository.AlbumList();
        return list.Any() ?  BuildResponse(list, "", HttpStatusCode.OK) : 
            BuildResponse(list, "", HttpStatusCode.NotFound);
    }

    public async Task<BaseMessage<Album>> AddAlbum(Album album)
    {
        var isValid = ValidateModel(album);
        if(string.IsNullOrEmpty(isValid))
        {
            return BuildResponse(null, isValid, HttpStatusCode.BadRequest, new());
        }

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

    private string ValidateModel(Album album)
    {
        string message = string.Empty;

        if(string.IsNullOrEmpty(album.name))
        {
            message = "El nombre es requerido";
        }
        if(album.year < 1901 || album.year > 2025)
        {
            message = "El año del disco debe estar entre 1901 y 2025";
        }
        return message;
    }

    #region Learning to Test
    public async Task<string> HealthCheckTest()
    {
        return "Ok";
    }

    public async Task<string> HealthCheckTest(bool IsOK)
    {
        return IsOK ? "OK!" : "Not cool";
    }

    public async Task<string> TestAlbumCreation(Album album)
    {
        return ValidateModel(album);
    }

    #endregion
}
