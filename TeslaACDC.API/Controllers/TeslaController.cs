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
    var list = await _albumService.GetAlbumList();

    return Ok(list);
  }

  [HttpPost]
  [Route("PostAlbums")]
  public async Task<IActionResult> PostAlbumsList(List<Album> albums)
  {
    var list = await _albumService.PostAlbumList(albums);

    return Ok(list);
  }


  [HttpPost]
  [Route("Addition")]
  public async Task<IActionResult> Addition(Addition addition)
  {
    var resAddition = await _matematikaService.Addition(addition);
    return Ok($"La suma de {addition.number_1} + {addition.number_2} = { resAddition }");
  }

  [HttpPost]
  [Route("AreaSquare")]
  public async Task<IActionResult> AreaSquare(Square square)
  {
    var areaSquare = await _matematikaService.AreaSquare(square);
    return Ok($"El área de un cuadrado cuyo lado mide {square.sideLenght} es : {areaSquare}^2");
  }

  [HttpPost]
  [Route("AreaSidesSquare")]
  public async Task<IActionResult> AreaSidesSquare(SidesSquare sidesSquare)
  {
    var areaSidesSquare = await _matematikaService.AreaSidesSquare(sidesSquare);
    if ( areaSidesSquare == 0 ){
      return Ok("Un cuadrado debe tener todos los lados iguales");
    } else {
      return Ok($"Los lados del cuadrado son {sidesSquare.sideLenght_1}, {sidesSquare.sideLenght_2}, {sidesSquare.sideLenght_3}, {sidesSquare.sideLenght_4} y su área es: {areaSidesSquare}^2");
    }
  }

  [HttpPost]
  [Route("AreaTriangle")]
  public async Task<IActionResult> AreaTriangle(Triangle triangle)
  {
    var areaTriangle = await _matematikaService.AreaTriangle(triangle);
    return Ok($"El área de un triangulo cuya base es {triangle.baseTriangle} y su altura es {triangle.heightTriangle} es {areaTriangle}^2");
  }

}
  