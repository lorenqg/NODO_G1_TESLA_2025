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

}
  