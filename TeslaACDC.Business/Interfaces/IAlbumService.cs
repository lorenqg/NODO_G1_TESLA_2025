using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Interfaces;

public interface IAlbumService
{
  public Task<BaseMessage<Album>> GetAlbums();
  public Task<BaseMessage<Album>> AddAlbum(Album album);
  public Task<BaseMessage<Album>> FindById(int id);
  public Task<BaseMessage<Album>> UpdateAlbum(int id, Album album);
  public Task<BaseMessage<Album>> DeleteById(int id);
}