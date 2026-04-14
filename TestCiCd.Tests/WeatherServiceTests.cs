using TestCiCd.Services;

namespace TestCiCd.Tests;

public class WeatherServiceTests
{
    private readonly WeatherService _weatherService;

    public WeatherServiceTests()
    {
        _weatherService = new WeatherService();
    }

    // ── GetSummary Tests ──────────────────────────────────

    [Fact]
    public void GetSummary_BelowZero_ReturnsFreezing()
    {
        // Arrange
        int temperature = -5;

        // Act
        string result = _weatherService.GetSummary(temperature);

        // Assert
        Assert.Equal("Freezing", result);
    }

    [Fact]
    public void GetSummary_Between0And10_ReturnsChilly()
    {
        // Arrange
        int temperature = 5;

        // Act
        string result = _weatherService.GetSummary(temperature);

        // Assert
        Assert.Equal("Chilly", result);
    }

    [Fact]
    public void GetSummary_Between10And20_ReturnsMild()
    {
        // Arrange
        int temperature = 15;

        // Act
        string result = _weatherService.GetSummary(temperature);

        // Assert
        Assert.Equal("Mild", result);
    }

    [Fact]
    public void GetSummary_Between20And30_ReturnsWarm()
    {
        // Arrange
        int temperature = 25;

        // Act
        string result = _weatherService.GetSummary(temperature);

        // Assert
        Assert.Equal("Warm", result);
    }

    [Fact]
    public void GetSummary_Above30_ReturnsScorching()
    {
        // Arrange
        int temperature = 35;

        // Act
        string result = _weatherService.GetSummary(temperature);

        // Assert
        Assert.Equal("Scorching", result);
    }

    // ── CelsiusToFahrenheit Tests ─────────────────────────

    [Fact]
    public void CelsiusToFahrenheit_Zero_Returns32()
    {
        // Arrange
        double celsius = 0;

        // Act
        double result = _weatherService.CelsiusToFahrenheit(celsius);

        // Assert
        Assert.Equal(32, result);
    }

    [Fact]
    public void CelsiusToFahrenheit_100_Returns212()
    {
        // Arrange
        double celsius = 100;

        // Act
        double result = _weatherService.CelsiusToFahrenheit(celsius);

        // Assert
        Assert.Equal(212, result);
    }

    // ── IsValidTemperature Tests ──────────────────────────

    [Fact]
    public void IsValidTemperature_NormalTemp_ReturnsTrue()
    {
        // Arrange
        int temperature = 25;

        // Act
        bool result = _weatherService.IsValidTemperature(temperature);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidTemperature_TooHot_ReturnsFalse()
    {
        // Arrange
        int temperature = 100;

        // Act
        bool result = _weatherService.IsValidTemperature(temperature);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidTemperature_TooCold_ReturnsFalse()
    {
        // Arrange
        int temperature = -100;

        // Act
        bool result = _weatherService.IsValidTemperature(temperature);

        // Assert
        Assert.False(result);
    }
}
