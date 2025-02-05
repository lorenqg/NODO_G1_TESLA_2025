using System;

namespace TeslaACDC.Data.Models;

public class Album : BaseEntity<int>
{
   public string name{get; set;} = String.Empty;
    public int year{get;set;}
    public Genre genre{get;set;} = Genre.Unknown;
}

public enum Genre
{
    Pop,
    Rock,
    Metal,
    Salsa,
    Urban,
    Folklore,
    Indie,
    Electronica,
    Vallenato,
    Tropipop,
    World,
    Lofi,
    RyB_Contemporáneo,

    Unknown    
}