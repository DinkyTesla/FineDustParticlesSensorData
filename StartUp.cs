
using FineDustParticlesSensorData.Core;

namespace FineDustParticlesSensorData
{
    public class StartUp
    {
        public static void Main()
        {
            Engine engine = new Engine();

            engine.Run();
            //SensorServices.GetSensorData();
        }
    }
}
