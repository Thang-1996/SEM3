using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Get_Weather_Location
{
    public class LocationData
    {
        public async static Task<Geoposition> getPosition()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            if (accessStatus != GeolocationAccessStatus.Allowed) throw new Exception();
            /*      if(accessStatus != GeolocationAccessStatus.Allowed)
            */
            var geolocator = new Geolocator{ DesiredAccuracyInMeters = 0};
            var position = await geolocator.GetGeopositionAsync();
            return position;
        }
    }
}
