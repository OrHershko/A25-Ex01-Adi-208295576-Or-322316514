﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookAppLogic
{
    public class WeatherReportBuilder
    {
        private string m_Date;
        private string m_City;
        private double m_Temperature;
        private double m_Humidity;
        private double m_Precipitation;

        public WeatherReportBuilder SetDate(string i_Date)
        {
            m_Date = i_Date;
            return this;
        }

        public WeatherReportBuilder SetCity(string i_City)
        {
            m_City = i_City;
            return this;
        }

        public WeatherReportBuilder SetTemperature(double i_Temperature)
        {
            m_Temperature = i_Temperature;
            return this;
        }

        public WeatherReportBuilder SetHumidity(double i_Humidity)
        {
            m_Humidity = i_Humidity;
            return this;
        }

        public WeatherReportBuilder SetPrecipitation(double i_Precipitation)
        {
            m_Precipitation = i_Precipitation;
            return this;
        }

        public string Build()
        {
            string htmlTemplate = $@"
<!DOCTYPE html>
<html>
<head>
    <title>Weather Report</title>
    <style>
        body {{ font-family: Arial, sans-serif; margin: 10px; }}
        h1 {{ color: #333; }}
        h2 {{ color: #555; }}
        p {{ color: #666; line-height: 0.8; }}
        .weather-container {{ border: 1px solid #ddd; padding: 15px; border-radius: 5px; max-width: 400px; }}
    </style>
</head>
<body>
    <h1>Weather Report for {m_City}</h1>
    <div class='weather-container'>
        <h2>Date: {m_Date}</h2>
        <p><strong>Average Temperature:</strong> {m_Temperature} °C</p>
        <p><strong>Average Humidity:</strong> {m_Humidity} %</p>
        <p><strong>Precipitation Probability:</strong> {m_Precipitation} %</p>
    </div>
</body>
</html>";

            return htmlTemplate;
        }

    }

}
