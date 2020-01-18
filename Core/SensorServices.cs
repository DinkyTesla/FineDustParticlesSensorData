using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FineDustParticlesSensorData
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

            //Logging including workaround when there is only one reading or none. Not tested.
            //This is skipping the last reading and it takes the one before it
            if (response.IsSuccessful && response.Data.Count > 1)
            {
                File.AppendAllText(path, response.Data.Skip(1).FirstOrDefault().TimeStamp.ToString() + "\n");

                foreach (var item in response.Data.Skip(1).FirstOrDefault().SensorDataValues)
                {
                    Console.WriteLine(item.ValueType.ToString());
                    Console.WriteLine(item.Value.ToString());

                    File.AppendAllText(path, item.ValueType.ToString() + " : ");
                    File.AppendAllText(path, item.Value.ToString() + "\n");
                }

                return response.Data.ToString();
            }
            //This reads the last reading if it is the only one.
            else if (response.IsSuccessful && response.Data.Count == 1)
            {
                foreach (var item in response.Data.FirstOrDefault().SensorDataValues)
                {
                    Console.WriteLine(item.ValueType.ToString());
                    Console.WriteLine(item.Value.ToString());

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
