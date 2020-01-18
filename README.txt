Hello, User!

#About
This is a small app for logging data readings from SDS011 / Nova Fitness sensor for fine dust particles.
The app reads the timestamp and the values and logs them in a .txt file.
The information is taken from a given sensor using REST API Call.

#Curiosity
The PM10 and PM2.5 particles are a big issue in metropolitan areas and become harmful above given levels for
prolonged periods of time. When inhaled may get into the lungs and even into the bloodsream.

#Resources
Documentation about the sensor API can be found here: https://github.com/opendata-stuttgart/meta/wiki/APIs 
and the particular sensor URI is: https://data.sensor.community/airrohr/v1/sensor/10001/
For the REST call I chose to use RestSharp: https://github.com/restsharp/RestSharp

#NB
1. I have found that sometimes the sensor skips several measurements and the data could be insufficient 
or not be retvieved at all. The issue is sporadic the implemented fix was not tested and is subject
of future refactoring.
2. I know about Test Driven Development but I am lacking the experience and as time has progressed 
Unit Testing is to be implemented.
