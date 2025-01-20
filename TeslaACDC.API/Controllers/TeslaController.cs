namespace TeslaACDC.Controllers;

using Microsoft.AspNetCore.Mvc;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Business.Services;
using TeslaACDC.Data.Models;
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
  public async Task<IActionResult> Addition(DtoAddition dtoAddition)
  {
    var addition = await _matematikaService.Addition(dtoAddition);
    return Ok($"La suma de {dtoAddition.number_1} + {dtoAddition.number_2} = { addition }");
  }

  [HttpPost]
  [Route("AreaSquare")]
  public async Task<IActionResult> AreaSquare(DtoSquare dtoSquare)
  {
    var areaSquare = await _matematikaService.AreaSquare(dtoSquare);
    return Ok($"El área de un cuadrado cuyo lado mide {dtoSquare.sideLenght} es : {areaSquare}^2");
  }

  [HttpPost]
  [Route("AreaSidesSquare")]
  public async Task<IActionResult> AreaSidesSquare(DtoSidesSquare dtoSidesSquare)
  {
    var areaSidesSquare = await _matematikaService.AreaSidesSquare(dtoSidesSquare);
    return Ok($"Los lados del cuadrado son {dtoSidesSquare.sideLenght_1}, {dtoSidesSquare.sideLenght_2}, {dtoSidesSquare.sideLenght_3}, {dtoSidesSquare.sideLenght_4} y su área es: {areaSidesSquare}^2");
  }

  [HttpPost]
  [Route("AreaTriangle")]
  public async Task<IActionResult> AreaTriangle(DtoTriangle dtoTriangle)
  {
    var areaTriangle = await _matematikaService.AreaTriangle(dtoTriangle);
    return Ok($"El área de un triangulo cuya base es {dtoTriangle.baseTriangle} y su altura es {dtoTriangle.heightTriangle} es {areaTriangle}^2");
  }

}
  