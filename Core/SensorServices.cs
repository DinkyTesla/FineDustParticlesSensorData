using System;
using RestSharp;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using FineDustParticlesSensorData.Data;
using FineDustParticlesSensorData.Data.Models;

namespace FineDustParticlesSensorData.Core
{
    public class SensorServices
    {
        private string URI;
        private string path;

        public SensorServices()
        {
            this.URI = Resources.GetURI();
            this.path = Resources.GetPath();
        }

        public string GetSensorData()
        {
            //Should be moved
            var client = new RestClient(URI);

            //Should be moved
            var response = client.Execute<List<ResponseData>>(new RestRequest());

            //Logging including workaround when there is only one reading or none. Not tested as it depends on the sensor readings.
            //This skips the last reading and it takes the one before it.
            //Code must be refactored.
            if (response.IsSuccessful && response.Data.Count > 1)
            {
                //Timestamp.
                File.AppendAllText(path, response.Data.Skip(1).FirstOrDefault().TimeStamp.ToString() + "\n");

                //PM10 and PM2.5 values.
                foreach (var item in response.Data.Skip(1).FirstOrDefault().SensorDataValues)
                {
                    File.AppendAllText(path, item.ValueType.ToString() + " : ");
                    File.AppendAllText(path, item.Value.ToString() + "\n");
                }

                return response.Data.ToString();
            }
            //This reads the last reading if it is the only one.
            else if (response.IsSuccessful && response.Data.Count == 1)
            {
                //Timestamp.
                File.AppendAllText(path, response.Data.FirstOrDefault().TimeStamp.ToString() + "\n");
                
                //PM10 and PM2.5 values.
                foreach (var item in response.Data.FirstOrDefault().SensorDataValues)
                {
                    File.AppendAllText(path, item.ValueType.ToString() + " : ");
                    File.AppendAllText(path, item.Value.ToString() + "\n");
                }

                return response.Data.ToString();
            }
            //This logs the error message.
            else
            {
                Console.WriteLine(response.ErrorMessage);
                return response.ErrorMessage.ToString();
            }
        }
    }
}
