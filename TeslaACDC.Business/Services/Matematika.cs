using TeslaACDC.Data.DTO;

namespace TeslaACDC.Business.Services;

public class Matematika : IMatematika
{
   public async Task<float> Addition(Addition addition)
    {
        var resultAddition = addition.number_1 + addition.number_2;
        return resultAddition;
    }

    public async Task<float> AreaSquare(Square square)
    {
      var resultSquare = square.sideLenght * square.sideLenght;
      return resultSquare;
    }
    public async Task<float> AreaSidesSquare(SidesSquare sidesSquare)
    {
      if (sidesSquare.sideLenght_1 == sidesSquare.sideLenght_2 && sidesSquare.sideLenght_1 == sidesSquare.sideLenght_3 && sidesSquare.sideLenght_1 == sidesSquare.sideLenght_4){
        return sidesSquare.sideLenght_1 * sidesSquare.sideLenght_2;
      } else {
        return 0;
      }
    }

    public async Task<float> AreaTriangle (Triangle triangle)
    {
      var resultTriangle = triangle.baseTriangle * triangle.heightTriangle/2;
      return resultTriangle;
    }

    

}
