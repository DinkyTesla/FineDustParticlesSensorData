Hello, User!

#About
This is a small app for logging data readings from SDS011 / Nova Fitness sensor for fine dust particles.
The app reads the timestamp and the values and logs them in a .txt file.
The information is taken from a given sensor using REST API Call.

#DidYouKnow
The SDS011 uses the principle of laser scattering to detect particles between 0.3 and 10 µm in the air.
The PM10 (between 10µm and 2.5µm in diameter) and PM2.5 (2.5µm and less in diameter) particles are a 
big issue in metropolitan areas and become harmful above given levels for prolonged periods of time.
When inhaled may get into the lungs and even into the bloodsream and cause concern for human health.

#StepsItTookToGetHere
1. I was curious what are those sensors and how they work and what they measure.
2. Had to understand what PM10 and PM2.5 stans for.
3. Then I had to find out the ID of the given sensor and how to acces its API.
4. Next I had to see the JSON it gives me to know what I need to filter.
5. Had to read alot about all the libraries and methods I was going to use.
6. After I decided I have gathered enough knowedge began the planning stage which took 
	place mainly in my head and several hand-drawn diagrams.
7. Then came the coding part which quickly began to return data. The biggest brainstorm
	was over mapping the objects data as I lack experience. I knew this is something 
	I am going to see everyday from now on so kept pushing myself until the breaktrough.
8. Finally refactoring was something that took almost as much time as the initial coding.

#Resources
Documentation about the sensor API can be found here: https://github.com/opendata-stuttgart/meta/wiki/APIs 
and the particular sensor URI is: https://data.sensor.community/airrohr/v1/sensor/6344/
For the REST call I chose to use RestSharp: https://github.com/restsharp/RestSharp
Some of my homeworks from SoftUni.
And of course Google :)

#NB
1. I have found that sometimes the sensor skips several measurements and the data could be insufficient 
or not be retvieved at all. The issue is sporadic the implemented fix was not fully tested and is subject
of future refactoring.
2. The timestamp from the sensor reading differs from the current time. Could be the sensor internal Time.
3. I know about Test Driven Development but I am lacking the experience and time. 
4. Unit Tests are to be implemented.