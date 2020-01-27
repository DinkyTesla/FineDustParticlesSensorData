namespace FineDustParticlesSensorData.Core
{
    //This should initiate all the services which are and will be needed.
    public class Engine
    {
        private SensorServices sensorServices;

        public Engine()
        {
            this.sensorServices = new SensorServices();
        }

        public void Run()
        {
            sensorServices.GetSensorData();
        }
    }
}
