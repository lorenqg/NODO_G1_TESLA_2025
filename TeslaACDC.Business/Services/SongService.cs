using System.Net;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.Models;
using TeslaACDC.Data.IRepository;

namespace TeslaACDC.Business.Services;

public class SongService : ISongService
{
  private ISongRepository<int, Song> _songRepository;

  public SongService(ISongRepository<int, Song> songRepository)
  {
    _songRepository = songRepository;
  }

  public async Task<BaseMessage<Song>> GetSongs()
  {
    var list = await _songRepository.SongList();
    return list.Any() ? BuildResponse(list, "", HttpStatusCode.OK) : 
            BuildResponse(list, "", HttpStatusCode.NotFound);
  }

  public async Task<BaseMessage<Song>> AddSong(Song song)
  {
    var isValid = ValidateModel(song);
    if (string.IsNullOrEmpty(isValid))
    {
      return BuildResponse(null, isValid, HttpStatusCode.BadRequest, new());
    }
    await _songRepository.AddAsync(song);

    if (song == null) 
    {
      return BuildResponse(new (), "", HttpStatusCode.BadRequest);
    }

    return BuildResponse(new List<Song> { song }, "Success", HttpStatusCode.OK);
  }

  private BaseMessage<Song> BuildResponse(List<Song> list, string message = "", HttpStatusCode status = HttpStatusCode.OK, int totalElements = 0)
  {
    return new BaseMessage<Song>(){
      Message = message,
      StatusCode = status,
      TotalElements = totalElements > 0 ? totalElements : list.Count,
      ResponseElements = list
    };
  }

  private string ValidateModel (Song song)
  {
    string message = string.Empty;

    if (string.IsNullOrEmpty(song.name))
    {
      message = "El nombre es requerido";
    }
    if (song.duration == 0)
    {
      message = "La duración es requerida";
    }
    return message;
  }

  #region learning to Test
  public async Task<string> TestSongCreation(Song song)
  {
    return ValidateModel(song);
  }
  #endregion
}