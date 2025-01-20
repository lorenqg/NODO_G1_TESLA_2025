using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Interfaces;

public interface IAlbumService
{

  Task<List<Album>> GetAlbumList();
  Task<List<Album>> PostAlbumList(List<Album> list);

}