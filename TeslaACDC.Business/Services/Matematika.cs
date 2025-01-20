using System;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Services;

public class Matematika : IMatematika
{
   public async Task<float> Addition(DtoAddition dtoAddition)
    {
        var addition = dtoAddition.number_1 + dtoAddition.number_2;
        return addition;
    }

    public async Task<float> AreaSquare(DtoSquare dtoSquare)
    {
      var square = dtoSquare.sideLenght * dtoSquare.sideLenght;
      return square;
    }
    public async Task<float> AreaSidesSquare(DtoSidesSquare dtoSidesSquare)
    {
      var square = (dtoSidesSquare.sideLenght_1 + dtoSidesSquare.sideLenght_2 + dtoSidesSquare.sideLenght_3 + dtoSidesSquare.sideLenght_4) / 2;
      return square;
    }

    public async Task<float> AreaTriangle (DtoTriangle dtoTriangle)
    {
      var triangle = dtoTriangle.baseTriangle * dtoTriangle.heightTriangle/2;
      return triangle;
    }

    

}
