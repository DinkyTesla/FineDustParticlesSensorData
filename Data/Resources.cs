
using System.Reflection;

namespace FineDustParticlesSensorData
{
    static class Resources
    {
        //This URI is fixed due to task constraints.
        private static readonly string Uri = "https://data.sensor.community/airrohr/v1/sensor/10001/";

       // private static readonly string path = @"..\..\..\DustSensorDataLog.txt";
         static string path =  Assembly.GetExecutingAssembly().Location + "Log.txt";

        public static string GetURI()
        {
            return Uri;
        }

        public static string GetPath()
        {
            return path;
        }
    }
}
