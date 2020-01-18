Hello, User!

#About
This is a small app for logging data readings from SDS011 / Nova Fitness sensor for fine dust particles.
The app reads the timestamp and the values and logs them in a .txt file.
The information is taken from a given sensor using REST API Call.

#Curiosity
The PM10 and PM2.5 particles become harmful above given levels for a prolonged period of time and are a
big issue in metropolitan areas. When inhaled may get into the lungs and even into the bloodsream.

#Resources
Documentation can be found here: https://github.com/opendata-stuttgart/meta/wiki/APIs and the particular
sensor URI is: https://data.sensor.community/airrohr/v1/sensor/10001/
For the REST call I chose to use RestSharp: https://github.com/restsharp/RestSharp

#NB
I have found that sometimes the sensor skips several measurements and the data could be retvieved from 
their collected logs. As this was found while the project was in it's final stage the fix is a subject 
of future refactoring of the code.
