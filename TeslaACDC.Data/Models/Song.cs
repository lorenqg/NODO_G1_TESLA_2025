using System;

namespace TeslaACDC.Data.Models;

public class Song : BaseEntity<int>
{
  public string name { get; set; } = String.Empty;
  public int duration { get; set; }
}