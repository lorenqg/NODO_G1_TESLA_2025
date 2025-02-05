using Microsoft.AspNetCore.Mvc;
using TeslaACDC.Business.Interfaces;

namespace TeslaACDC.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArtistController : ControllerBase
{
    private readonly IArtistService _artistService;

    public ArtistController(IArtistService artistService)
    {
        _artistService = artistService;
    }

    [HttpGet]
    [Route("GetArtists")]
    public async Task<IActionResult> GetArtists()
    {
        var artist = await _artistService.GetArtists();
        return Ok(artist);
    }

    [HttpPost]
    [Route("AddArtist")]
    public async Task<IActionResult> AddArtist(Artist artist)
    {
        var res = await _artistService.AddArtist(artist);
        return Ok(res);
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        var artist = await _artistService.FindById(id);
        return Ok(artist);
    }

     [HttpPut]
    [Route("UpdateById")]
    public async Task<IActionResult> UpdateById(int id, Artist artist)
    {
        var res = await _artistService.UpdateArtist(id, artist);
        return Ok(res);
    }

    [HttpDelete]
    [Route("DeleteById")]
    public async Task<IActionResult> DeleteById(int id)
    {
        var artist = await _artistService.DeleteById(id);
        return Ok(artist);
    }
}