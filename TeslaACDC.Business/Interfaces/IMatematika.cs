using TeslaACDC.Data.DTO;
public interface IMatematika
{
  
  Task<float> Addition(Addition addition);
  Task<float> AreaSquare(Square square);
  Task<float> AreaSidesSquare(SidesSquare sidesSquare);
  Task<float> AreaTriangle(Triangle triangle);

}