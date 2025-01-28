using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Services;

public class AlbumService : IAlbumService
{
    private List<Album> _albumList = new();

    public AlbumService()
    {
        _albumList.Add(new (){Id = 1, name = "Cross Road", year = 1994, genre= Genre.Rock, Artist = new() {Id = 1, Name = "Bon Jovi", Label = "Mercury Records", IsOnTour = false}});
        _albumList.Add(new (){Id = 2, name = "AM", year = 2013, genre= Genre.Indie, Artist = new() {Id = 2, Name = "Arctic Monkeys", Label = "Dominio Records", IsOnTour = false}});
        _albumList.Add(new (){Id = 3, name = "After Hours", year = 2020, genre= Genre.RyB_Contemporáneo, Artist = new() {Id = 3, Name = "The Weeknd", Label = "Republic Records - XO", IsOnTour = true}});
        _albumList.Add(new (){Id = 4, name = "Smithereens", year = 2022, genre= Genre.Lofi, Artist = new() {Id = 4, Name = "Joji", Label = "88rising", IsOnTour = false}});
    }

    public async Task<BaseMessage<Album>> GetAlbumList()
    {
        return new BaseMessage<Album>() {
            Message = "",
            StatusCode = HttpStatusCode.OK,
            TotalElements = _albumList.Count,
            ResponseElements = _albumList
        };
    }

    public async Task<BaseMessage<Album>> PostAlbum()
    {
        try{
            _albumList.Add(new (){Id = 5, name = "Night Visions", year = 2012, genre = Genre.Pop, Artist = new(){Id = 5, Name= "Imagine Dragons", Label="KIDinaKORNER", IsOnTour=true}});
        }catch{
            return new BaseMessage<Album>() {
                Message = "",
                StatusCode = HttpStatusCode.InternalServerError,
                TotalElements = 0,
                ResponseElements = new ()
            };
        }
        
        return new BaseMessage<Album>() {
            Message = "",
            StatusCode = HttpStatusCode.OK,
            TotalElements = _albumList.Count,
            ResponseElements = _albumList
        };
        
    }

    public async Task<BaseMessage<Album>> GetAlbumById(int id)
    {
        var list = _albumList.Where(x => x.Id == id).ToList();

         return list.Any() ?  BuildResponse(list, "", HttpStatusCode.OK, list.Count) : 
            BuildResponse(list, "", HttpStatusCode.NotFound, 0);
    }

    public async Task<BaseMessage<Album>> GetAlbumByName(string name)
    {
        var list = _albumList.FindAll(x => x.name.ToLower().Contains(name.ToLower()));

         return list.Any() ?  BuildResponse(list, "", HttpStatusCode.OK, list.Count) : 
            BuildResponse(list, "", HttpStatusCode.NotFound, 0);
    }

    public async Task<BaseMessage<Album>> GetAlbumsByYear(int year)
    {
        var list = _albumList.FindAll(x => x.year == year);

         return list.Any() ?  BuildResponse(list, "", HttpStatusCode.OK, list.Count) : 
            BuildResponse(list, "", HttpStatusCode.NotFound, 0);
    }

    public async Task<BaseMessage<Album>> GetAlbumsBetweenYears(int yearOne, int yearTwo)
    {
        var list = _albumList.FindAll(x => x.year >= yearOne & x.year <= yearTwo);

         return list.Any() ?  BuildResponse(list, "", HttpStatusCode.OK, list.Count) : 
            BuildResponse(list, "", HttpStatusCode.NotFound, 0);
    }

    public async Task<BaseMessage<Album>> GetAlbumsByGenre(int? genreId, string? genre)
    {
        var list = _albumList.FindAll(x => genreId == null ? x.genre.ToString().ToLower().Contains(genre.ToLower()) : x.genre == (Genre)genreId);

         return list.Any() ?  BuildResponse(list, "", HttpStatusCode.OK, list.Count) : 
            BuildResponse(list, "", HttpStatusCode.NotFound, 0);
    }

    public async Task<BaseMessage<Album>> GetAlbumsByArtist(string artist)
    {
        var list = _albumList.FindAll(x => x.Artist.Name.ToLower().Contains(artist.ToLower()));

         return list.Any() ?  BuildResponse(list, "", HttpStatusCode.OK, list.Count) : 
            BuildResponse(list, "", HttpStatusCode.NotFound, 0);
    }

    private BaseMessage<Album> BuildResponse(List<Album> list, string message = "", HttpStatusCode status = HttpStatusCode.OK, int totalElements = 0)
    {
        return new BaseMessage<Album>(){
            Message = message,
            StatusCode = status,
            TotalElements = totalElements,
            ResponseElements = list
        };
    }
}
