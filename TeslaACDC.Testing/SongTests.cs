using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeslaACDC.Business.Services;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Tests;

[TestClass]
public class SongTests
{
  public SongTests()
  {

  }

  [TestMethod]
  public async Task ValidateSongCreation()
  {
    // Arrange
    var service = new SongService(null);
    var song = new Song(){
      name = "Antídoto y Veneno",
      duration = 319,
      Id = 1
    };

    // Act
    var response = await service.TestSongCreation(song);

    // Assert
    Assert.AreEqual(response, String.Empty);
  }

  [TestMethod]
  public async Task ValidateSongCreation_nameisempty()
  {
    // Arrange
    var service = new SongService(null);
    var song = new Song(){
      name = "",
      duration = 319,
      Id = 1
    };

    // Act
    var response = await service.TestSongCreation(song);

    //Assert
    Assert.IsTrue(response.Contains("El nombre es requerido"));
  }

  [TestMethod]
  public async Task ValidateSongCreation_durationisempty()
  {
    // Arrange
    var service = new SongService(null);
    var song = new Song(){
      name = "Antídoto y Veneno",
      duration = 0,
      Id = 1
    };

    // Act
    var response = await service.TestSongCreation(song);

    //Assert
    Assert.IsTrue(response.Contains("La duración es requerida"));
    }
}