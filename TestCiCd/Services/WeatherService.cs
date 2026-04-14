namespace TestCiCd.Services
{
    public class WeatherService
    {
        /// <summary>
        /// Gets a weather summary based on temperature in Celsius.
        /// </summary>
        public string GetSummary(int temperatureCelsius)
        {
            if (temperatureCelsius < 0)
                return "Freezing";
            else if (temperatureCelsius < 10)
                return "Chilly";
            else if (temperatureCelsius < 20)
                return "Mild";
            else if (temperatureCelsius < 30)
                return "Warm";
            else
                return "Scorching";
        }

        /// <summary>
        /// Converts Celsius to Fahrenheit.
        /// </summary>
        public double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        /// <summary>
        /// Validates if temperature is within a realistic range.
        /// </summary>
        public bool IsValidTemperature(int temperatureCelsius)
        {
            return temperatureCelsius >= -90 && temperatureCelsius <= 60;
        }
    }
}
