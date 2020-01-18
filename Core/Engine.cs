using System;
using System.Collections.Generic;
using System.Text;

namespace FineDustParticlesSensorData.Core
{
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
