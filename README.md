# C-WeatherApp


This client application which can run on windows or linux which takes an input name of a city and provides information about the weather for that city. I developed my program using C# in Visual Studios for the convenience of using the extension JSON deserializer - there are two files here : Program.cs and RootObject.cs. RootObject.cs contains all of the declarations for weather details used in my program such as data types/getters and setters for current temperature, pressure, humidity, cloud, visibility, minimum temperature, maximum temperature, latitude, longitude, speed and degree of wind. To invoke, I simply called “weatherDetails.” + class name + object.

  In my design, I used a while(true) loop to ask for a city name indefinitely until the user types “Exit” to leave the program. After signing up with this open weather data website (http://api.openweathermap.org/data/2.5/") - they provided me with an API key in which I could use to make REST calls from the open weather API. If the input is either null or empty, then the program will break, if an invalid input is entered then an exception will be caught - failed response code will also be printed. The base URL used to extract information from 200,000 cities : "weather?q=" + city + "&APPID=NULL". 
  
	After installing the NewtonSoft.Json package, I grabbed the JSON data then do edit -> paste special -> paste JSON. I also converted temperature from Kelvin to Farenheit using this formula : (int)((int)(kelvinTemp - 273.15) * 1.8 + 32. After deserializing data from the schema, it prints all the weather details to console until the user wants to exit the application.


