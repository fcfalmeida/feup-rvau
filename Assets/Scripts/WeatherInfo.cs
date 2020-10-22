using System;

[Serializable]
public class WeatherInfo {

    public Weather[] weather;

    [Serializable]
    public class Weather {

        public int id;
        public string main;
        public string description;
    }
}