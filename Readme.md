[![NuGet](https://img.shields.io/nuget/v/LoggingHelper.svg)](https://www.nuget.org/packages/LoggingHelper/)

<img src="https://raw.githubusercontent.com/stevenrskelton/flag-icon/master/png/16/country-4x3/br.png" width=2.0% height=2.0%> Veja a documentação em português [clicando aqui](LoggingHelper/Globalization/Readme_pt-br.md).<br/>

# LoggingHelper
Library for easy logging.<br/>

<img src="LoggingHelper\Images\LoggingHelper_publish.png" width=100% height=100%><br/>


## AVAILABLE FEATURES:<br/>
✔ Allows logging with different levels of severity;<br/>
✔ Use the `Write` method to write logs to the file;<br/>
✔ Use the `LevelStack` property to define the maximum level to be considered in the method stack;<br/>
✔ The `LogValidity` property allows defining the maximum time (in days) for the log file to be reset;<br/>
✔ `LogLevel` represents the minimum level of log to be recorded in the file;<br/>
✔ The `LogPath` property define the location and file where the log should be recorded;<br/>
✔ Use the `Check` method to perform all validations before writing the log;<br/>
✔ `GetCallingMethodName` allows to identify who called considering stack level;<br/>
✔ Old logs can be automatically deleted through the initial check method (`Check`);<br/>
✔ More features coming soon.<br/>  

<br/><br/>

## INSTALLATION:
```
 dotnet add package LoggingHelper --version 1.1.0
```

<br/><br/>

## EXAMPLE OF USE
### Code:
```c#

using LH;

namespace App
{
    static class Program
    {
        static void Main()
        {
            try
            {                
                LoggingHelper.Write("This is a trace log message.", 0, "Start application.");
                LoggingHelper.Write("Debug message.", 1, null);
                LoggingHelper.Write("This is a message for an information log.", 2, null);             
                LoggingHelper.Write("This is also a message for an information log.", LoggingHelper.Level.INFO, null); 
            }
            catch (Exception ex)
            {
                LoggingHelper.Write("This is a log message for logging errors!", 4, ex.Message);
            }            
        }
    }
}

```


### Result:
```console
20/08/2023 14:06:56 [TRACE] (/Main) This is a trace log message. | Start application.
20/08/2023 14:06:56 [DEBUG] (/Main) Debug message.
20/08/2023 14:06:56 [INFO] (/Main) This is a message for an information log.
20/08/2023 14:06:56 [INFO] (/Main) This is also a message for an information log.
20/08/2023 14:06:56 [ERROR] (/Main) This is a log message for logging errors! | Exception of type 'System.Exception' was thrown.
```