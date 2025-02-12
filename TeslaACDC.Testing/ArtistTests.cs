using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeslaACDC.Business.Services;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Tests;

[TestClass]
public class ArtistTests
{
  public ArtistTests()
  {

  }

  [TestMethod]
  public async Task ValidateArtistCreation()
  {
    // Arrange
    var service = new ArtistService(null);
    var artist = new Artist(){
      Name = "Joji",
      IsOnTour = false,
      Label = "88 risings",
      Id = 1
    };

    // Act
    var response = await service.TestArtistCreation(artist);

    // Assert
    Assert.AreEqual(response, String.Empty);
  }

  [TestMethod]
  public async Task ValidateArtistCreation_nameisempty()
  {
    // Arrange
    var service = new ArtistService(null);
    var artist = new Artist(){
      Name = "",
      IsOnTour = false,
      Label = "88 risings",
      Id = 1
    };

    // Act
    var response = await service.TestArtistCreation(artist);

    //Assert
    Assert.IsTrue(response.Contains("El nombre es requerido"));
    }
}