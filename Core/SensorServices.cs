﻿using System;
using RestSharp;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using FineDustParticlesSensorData.Data;
using FineDustParticlesSensorData.Data.Models;

namespace FineDustParticlesSensorData.Core
{
    //Here we fetch te data.
    public class SensorServices
    {
        private string URI;
        private string path;
        private RestClient client;
        private IRestResponse<List<ResponseData>> response;

        public SensorServices()
        {
            this.URI = Resources.GetURI();
            this.path = Resources.GetPath();
            this.client = new RestClient(URI);
        }

        public string GetSensorData()
        {
            try
            {
                //To be moved and refactored.
                response = client.Execute<List<ResponseData>>(new RestRequest());

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
                    File.AppendAllText(path, response.ErrorMessage.ToString() + "\n");
                    return response.ErrorMessage.ToString();
                }
            }
            catch (Exception e)
            {
                File.AppendAllText(path, e.Message + "\n");
                return e.Message;
            }
            finally
            {
                    File.AppendAllText(path, "App execution run at: " 
                        + DateTime.Now.ToShortTimeString() + "\n" 
                        + "#\n");
            }
        }
    }
}
