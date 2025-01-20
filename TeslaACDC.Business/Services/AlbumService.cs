using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Services;

public class AlbumService : IAlbumService
{
    public async Task<List<Album>> GetAlbumList()
    {
        List<Album> albums = new() {
            new Album{
            name = "AM",
            year = 2013,
            genre = "Indie Rock",
            artist = "Arctic Monkeys"
            },
            new Album{
            name = "After Hours",
            year = 2020,
            genre = "R&B contemporáneo",
            artist = "The Weekend"
            },
            new Album{
            name = "Smithereens",
            year = 2022,
            genre = "Lo-fi",
            artist = "Joji"
            }
        };
        return albums ;
    }

     public async Task<List<Album>> PostAlbumList(List<Album> list)
    {
        return list;
    }

}