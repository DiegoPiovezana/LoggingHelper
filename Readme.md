[![NuGet](https://img.shields.io/nuget/v/LoggingHelper.svg)](https://www.nuget.org/packages/LoggingHelper/)

<img src="https://raw.githubusercontent.com/stevenrskelton/flag-icon/master/png/16/country-4x3/br.png" width=2.0% height=2.0%> Veja a documentação em português [clicando aqui](LoggingHelper/Globalization/Readme_pt-br.md).<br/>

# LoggingHelper
Library for easy logging.<br/>

<img src="LoggingHelper\Images\LoggingHelper_publish.png" width=100% height=100%><br/>


## AVAILABLE FEATURES:<br/>
✔ Allows logging with different severity levels;<br/>
✔ Use the `Write` method to write logs;<br/>
✔ Customize log output format using `FormatLogOutput`;<br/>
✔ Use the `LevelStack` property to set the maximum level to be considered in the method stack;<br/>
✔ The `LogValidity` property allows setting the maximum time (in days) for the log file to be reset;<br/>
✔ `LogLevelFile` represents the minimum log level to be recorded in the file;<br/>
✔ The `LogPathFile` property defines the location and file where the log should be recorded;<br/>
✔ `LogLevelConsole` sets the minimum log level to be recorded on the console;<br/>
✔ Modify the `Level` enum to customize log levels;<br/>
✔ Set the log level using enumeration, number, or text;<br/>
✔ Use the `CheckFile` method to hide the log directory and perform validations;<br/>
✔ `GetCallingMethodName` allows identifying the method that logged the message considering the stack level;<br/>
✔ Old log files can be automatically deleted through the check method (`CheckFile`);<br/> 
✔ More features coming soon.<br/>


<br/><br/>

## FEEDBACK:
https://bit.ly/FeedbackHappyHelper

<br/><br/>

## INSTALLATION:
```
 dotnet add package LoggingHelper --version 1.2.0
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
                // Optional
                //LoggingHelper.CheckFile(2,false);
                LoggingHelper.FormatLogOutput = "[<level>] <yyyy-MM-dd HH:mm:ss.fff> (<stack>) <message> | <obs>";
                //LoggingHelper.LevelStack = 3;
                //LoggingHelper.LogValidity = 2;

                //LoggingHelper.LogPathFile = @".\LOG_TEST\Logging_general.log";
                //LoggingHelper.LogLevelFile = 0;
                //LoggingHelper.LogLevelConsole = 0;

                LoggingHelper.Write("This is a trace log message.", 0, "Start application.");
                LoggingHelper.Write("Debug message.", 1, null);
                LoggingHelper.Write("This is a message for an information log [2].", 2, null);
                LoggingHelper.Write("This is also a message for an information log [3].", LoggingHelper.Level.INFO, null);
                LoggingHelper.Write("This is also a message for an information log [4].", "INFO", null);
                LoggingHelper.Write("This is also a message for an information log [5].", "2", null);

                throw new Exception();
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
[TRACE] 2024-02-01 14:23:18.721 (/Main) This is a trace log message. | Start application.
[DEBUG] 2024-02-01 14:23:18.725 (/Main) Debug message.
[INFO] 2024-02-01 14:23:18.725 (/Main) This is a message for an information log [2].
[INFO] 2024-02-01 14:23:18.726 (/Main) This is also a message for an information log [3].
[INFO] 2024-02-01 14:23:18.727 (/Main) This is also a message for an information log [4].
[INFO] 2024-02-01 14:23:18.727 (/Main) This is also a message for an information log [5].
[ERROR] 2024-02-01 14:23:18.728 (/Main) This is a log message for logging errors! | Exception of type 'System.Exception' was thrown.
```