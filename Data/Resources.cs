using System.Reflection;

namespace FineDustParticlesSensorData.Data
{
    static class Resources
    {
        //This URI is fixed due to task constraints.
        private static readonly string Uri = "https://data.sensor.community/airrohr/v1/sensor/6344/";

        //Generates the log file.
        private static string path = Assembly.GetExecutingAssembly().Location + "Log.txt";

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
