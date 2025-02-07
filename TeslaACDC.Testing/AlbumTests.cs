using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeslaACDC.Business.Services;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Tests;

[TestClass]
public class AlbumTests
{
  public AlbumTests()
  {

  }

   [TestMethod]
    public async Task HealthCheckTest()
    {
        // Arrange
        var service = new AlbumService(null);

        // Act
        var response = await service.HealthCheckTest();

        // Assert
        Assert.AreEqual(response, "Ok");
    }

    [TestMethod]
    public async Task HealthCheckTestIsOk()
    {
        // Arrange
        var service = new AlbumService(null);

        // Act
        var response = await service.HealthCheckTest(true);

        // Assert
        Assert.AreEqual(response, "OK!");
    }

    [TestMethod]
    public async Task HealthCheckTestIsNotOkay()
    {
        // Arrange
        var service = new AlbumService(null);

        // Act
        var response = await service.HealthCheckTest(false);

        // Assert
        Assert.AreEqual(response, "Not cool");
    }

  [TestMethod]
  public async Task ValidateAlbumCreation()
  {
    // Arrange
    var service = new AlbumService(null);
    var album = new Album(){
      name = "Ballads 1",
      year= 2018,
      ArtistId = 1,
      genre =  Genre.Pop,
      Id = 1
    };

    // Act
    var response = await service.TestAlbumCreation(album);

    // Assert
    Assert.AreEqual(response, String.Empty);

  }

  [TestMethod]
  public async Task ValidateAlbumCreation_nameisempty()
  {
    // Arrange
    var service = new AlbumService(null);
    var album = new Album(){
      name = "",
      year= 2018,
      ArtistId = 1,
      genre =  Genre.Pop,
      Id = 1
    };

    // Act
    var response = await service.TestAlbumCreation(album);

    //Assert
    Assert.IsTrue(response.Contains("El nombre es requerido"));

    }

  [TestMethod]
  public async Task ValidateAlbumCreation_yearoutofrangelower()
  {
    // Arrange
    var service = new AlbumService(null);
    var album = new Album(){
      name = "",
      year= 1889,
      ArtistId = 1,
      genre =  Genre.Indie,
      Id = 1
    };

    // Act
    var response = await service.TestAlbumCreation(album);

    //Assert
    Assert.IsTrue(response.Contains("El año del disco debe estar entre 1901 y 2025"));

  }

  [TestMethod]
  public async Task ValidateAlbumCreation_yearoutofrangehigher()
  {
    // Arrange
    var service = new AlbumService(null);
    var album = new Album(){
      name = "",
      year= 2026,
      ArtistId = 1,
      genre =  Genre.Vallenato,
      Id = 1
    };

    // Act
    var response = await service.TestAlbumCreation(album);

    //Assert
    Assert.IsTrue(response.Contains("El año del disco debe estar entre 1901 y 2025"));
  }

}