namespace TeslaACDC.Controllers;

using Microsoft.AspNetCore.Mvc;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Business.Services;
using TeslaACDC.Data.Models;
using TeslaACDC.Data.DTO;
[ApiController]
[Route("api/[controller]")]
public class TeslaController : ControllerBase
{

  private readonly IAlbumService _albumService;
  private readonly IMatematika _matematikaService;

    public TeslaController(IAlbumService albumService, IMatematika matematikaService)
    {
        _albumService = albumService;
        _matematikaService = matematikaService;
    }

  [HttpGet]
  [Route("GetAlbums")]
  public async Task<IActionResult> GetAlbumList()
  {
    return Ok(await _albumService.GetAlbumList());
  }

  [HttpPost]
  [Route("PostAlbums")]
  public async Task<IActionResult> PostAlbumsList()
  {
    return Ok(await _albumService.PostAlbum());
  }

  [HttpGet]
  [Route("GetAlbumById")]
  public async Task<IActionResult> GetAlbumById(int id)
  {
    var response = await _albumService.GetAlbumById(id);
    return StatusCode((int)response.StatusCode, response);
  }

  [HttpGet]
  [Route("GetAlbumByName")]
  public async Task<IActionResult> GetAlbumByName(string name)
  {
    var response = await _albumService.GetAlbumByName(name);
    return StatusCode((int)response.StatusCode, response);
  }

  [HttpGet]
  [Route("GetAlbumsByYear")]
  public async Task<IActionResult> GetAlbumsByYear(int year)
  {
    var response = await _albumService.GetAlbumsByYear(year);
    return StatusCode((int)response.StatusCode, response);
  }

  [HttpGet]
  [Route("GetAlbumsBtYears")]
  public async Task<IActionResult> GetAlbumBtName(int yearOne,int yearTwo)
  {
    var response = await _albumService.GetAlbumsBetweenYears(yearOne, yearTwo);
    return StatusCode((int)response.StatusCode, response);
  }

  [HttpGet]
  [Route("GetAlbumsByGenre")]
  public async Task<IActionResult> GetAlbumByGenre(int? genreId, string? genre)
  {
    var response = await _albumService.GetAlbumsByGenre(genreId, genre);
    return StatusCode((int)response.StatusCode, response);
  }

  [HttpGet]
  [Route("GetAlbumsByArtist")]
  public async Task<IActionResult> GetAlbumsByArtist(string artist)
  {
    var response = await _albumService.GetAlbumsByArtist(artist);
    return StatusCode((int)response.StatusCode, response);
  }

}
  