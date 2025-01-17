namespace TeslaACDC.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TeslaACDC.Model;
[ApiController]
[Route("api/[controller]")]
public class TeslaController : ControllerBase
{

  [HttpGet]
  [Route("GetArrayAlbums")]
  public async Task<IActionResult> GetArrayAlbums()
  {
    List<Album> albums = new List<Album>();
    albums.Add(new Album{
      name = "AM",
      year = 2013,
      genre = "Indie Rock",
      artist = "Arctic Monkeys"
    });
    albums.Add(new Album{
      name = "After Hours",
      year = 2020,
      genre = "R&B contemporáneo",
      artist = "The Weekend"
    });
    albums.Add(new Album{
      name = "Smithereens",
      year = 2022,
      genre = "Lo-fi",
      artist = "Joji"
    });

    return Ok(albums);
  }

  [HttpPost]
  [Route("PostArrayAlbums")]
  public async Task<IActionResult> PostArrayAlbums(List<Album> albums)
  {
    return Ok(albums);
  }


  [HttpPost]
  [Route("Addition")]
  public async Task<IActionResult> Addition(Addition addition)
  {
    var result =  addition.number_one + addition.number_two;
    return Ok("La suma de: " + addition.number_one + " + " + + addition.number_two + " = " + result);
  }

  [HttpPost]
  [Route("AreaSquare")]
  public async Task<IActionResult> AreaSquare(Square square)
  {
    var area = square.side * square.side;
    return Ok("El área de un cuadrado cuyo lado mide " + square.side + " es igual a " + area);
  }

}
  