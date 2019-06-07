using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Device.Location;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace GSAppLogic.Services
{
    public class Geolocation
    {
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        private static Geolocation geolocation;
        private string getCurrentGeolocationMap = $@"{Directory.GetCurrentDirectory()}\Scripts\getCurrentGeolocation.html";
        private GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
        
        private Geolocation() { }

        private Geolocation TryToGetGeolocation()
        {
            watcher.Start();

            if (!watcher.Position.Location.IsUnknown)
            {
                geolocation.Latitude = watcher.Position.Location.Latitude;
                geolocation.Longtitude = watcher.Position.Location.Longitude;
            }

            if (watcher == null)
            {
                watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
                watcher.MovementThreshold = 20;
            }

            return geolocation;
        }

        public static Geolocation GetInstance()
        {
            return geolocation == null ? new Geolocation() : geolocation;
        }

        public static Geolocation GetGeolocation()
        {
            geolocation = GetInstance();
            bool exit = false;
            while (!exit)
            {
                var coordinates = geolocation.TryToGetGeolocation();
                if (coordinates.Latitude > 0)
                {
                    exit = true;
                    geolocation.Longtitude = coordinates.Longtitude;
                    geolocation.Latitude = coordinates.Latitude;
                }
            }
            return geolocation;
        }
        
        public double CalculateLengthToGS(double GSLat, double GSLng)
        {
            geolocation = geolocation ?? GetGeolocation();
            var coordinateCurrentPos = new GeoCoordinate(geolocation.Latitude, geolocation.Longtitude);
            var coordinateGS = new GeoCoordinate(GSLat, GSLng);
            var distance = coordinateCurrentPos.GetDistanceTo(coordinateGS) / 1000;
            return distance;
        }

        public string GetCurrentPositionOnMap(string mapPath)
        {
            geolocation = GetGeolocation();
            StreamReader sr = new StreamReader(mapPath);
            string line = "";
            line = sr.ReadToEnd();
            sr.Close();
            line = line.Replace("lat: 53.889713,lng: 27.558095", $"lat: {geolocation.Latitude.ToString().Replace(',', '.')},lng: {geolocation.Longtitude.ToString().Replace(',', '.')}");
            line = line.Replace("//curPosMarker", @"var curPos = new google.maps.Marker({
                                    map: map,
                                    animation: google.maps.Animation.DROP,
                                    position: myLatLng,
                                    title: 'You are here',
                                    icon: image
                                    }); ");
            StreamWriter page = File.CreateText(getCurrentGeolocationMap);
            page.Write(line);
            page.Close();

            return Path.GetFullPath(getCurrentGeolocationMap);
        }
    }

    
}
