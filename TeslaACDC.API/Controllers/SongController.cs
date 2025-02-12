using Microsoft.AspNetCore.Mvc;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SongController : ControllerBase
{
  private readonly ISongService _songService;

  public SongController(ISongService songService)
  {
    _songService = songService;
  }

  [HttpGet]
  [Route("GetSongs")]
  public async Task<IActionResult> GetSongs()
  {
    var song = await _songService.GetSongs();
    return Ok(song);
  }

  [HttpPost]
  [Route("AddSong")]
  public async Task<IActionResult> AddSong(Song song)
  {
    var res = await _songService.AddSong(song);
    return Ok(res);
  }
}