using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Android;

public class WeatherController : MonoBehaviour
{
    public GameObject rain;

    void Start()
    {
        StartCoroutine("StartLocationService");
    }

    private void SetWeather(bool locationAvailable, float lat, float lon)
    {
        string url = "";
        string DEFAULT_LOCATION = "Porto";

        if (locationAvailable)
            url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid=0f821e54da7af1704509205f6122aaaf";
        else
        {
            Debug.Log("Location unavailable. Using default location: " + DEFAULT_LOCATION);
            url = $"https://api.openweathermap.org/data/2.5/weather?q={DEFAULT_LOCATION}&appid=0f821e54da7af1704509205f6122aaaf";
        }

        HttpWebRequest req = (HttpWebRequest) WebRequest.Create(url);
        
        WebResponse response = req.GetResponse();

        using (Stream dataStream = response.GetResponseStream())
        {
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            WeatherInfo weatherInfo = JsonUtility.FromJson<WeatherInfo>(responseFromServer);

            Debug.Log("Current weather: " + weatherInfo.weather[0].main);
            
            switch (weatherInfo.weather[0].main)
            {
                case "Rain":
                    SetRaining();
                    break;
                default:
                    break;
            }
        }

        response.Close();
    }

    private void SetRaining()
    {
        rain.SetActive(true);
    }

    private IEnumerator StartLocationService()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Location Service not enabled");
            SetWeather(false, 0, 0);
            yield break;
        }

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            SetWeather(false, 0, 0);
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            SetWeather(false, 0, 0);
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            SetWeather(true, Input.location.lastData.latitude, Input.location.lastData.longitude);
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }
}
