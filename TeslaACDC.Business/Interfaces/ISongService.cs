using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Interfaces;

public interface ISongService
{
  public Task<BaseMessage<Song>> GetSongs();
  public Task<BaseMessage<Song>> AddSong(Song song);

  #region learning to Test
  public Task<string> TestSongCreation(Song song);
  #endregion
}