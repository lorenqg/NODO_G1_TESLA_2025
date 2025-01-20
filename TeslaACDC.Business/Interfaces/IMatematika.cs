using TeslaACDC.Data.Models;

public interface IMatematika
{
  
  Task<float> Addition(DtoAddition dtoAddition);
  Task<float> AreaSquare(DtoSquare dtoSquare);
  Task<float> AreaSidesSquare(DtoSidesSquare dtoSidesSquare);
  Task<float> AreaTriangle(DtoTriangle dtoTriangle);

}