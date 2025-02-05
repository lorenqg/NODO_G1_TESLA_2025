using Microsoft.AspNetCore.Mvc;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumService;

    public AlbumController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    [HttpGet]
    [Route("GetAlbums")]
    public async Task<IActionResult> GetAlbums()
    {
        var album = await _albumService.GetAlbums();
        return Ok(album);
    }

    [HttpPost]
    [Route("AddAlbum")]
    public async Task<IActionResult> AddAlbum(Album album)
    {
        var res = await _albumService.AddAlbum(album);
        return Ok(res);
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        var album = await _albumService.FindById(id);
        return Ok(album);
    }

     [HttpPut]
    [Route("UpdateById")]
    public async Task<IActionResult> UpdateById(int id, Album album)
    {
        var res = await _albumService.UpdateAlbum(id, album);
        return Ok(res);
    }

    [HttpDelete]
    [Route("DeleteById")]
    public async Task<IActionResult> DeleteById(int id)
    {
        var album = await _albumService.DeleteById(id);
        return Ok(album);
    }

}