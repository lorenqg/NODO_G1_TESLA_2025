using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Interfaces;

public interface IArtistService
{
    public Task<BaseMessage<Artist>> GetArtists();
    public Task<BaseMessage<Artist>> AddArtist(Artist artist);
    public Task<BaseMessage<Artist>> FindById(int id);
    public Task<BaseMessage<Artist>> UpdateArtist(int id, Artist artist);
    public Task<BaseMessage<Artist>> DeleteById(int id);

    #region learning to Test
    public Task<string> TestArtistCreation(Artist artist);
    #endregion
}