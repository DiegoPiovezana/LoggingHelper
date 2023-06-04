[![NuGet](https://img.shields.io/nuget/v/LoggingHelper.svg)](https://www.nuget.org/packages/LoggingHelper/)

<img src="https://raw.githubusercontent.com/stevenrskelton/flag-icon/master/png/16/country-4x3/br.png" width=2.0% height=2.0%> Veja a documentação em português em breve.<br/>

# LoggingHelper
Library for easy logging..<br/>

<img src="LoggingHelper\Images\LoggingHelper_publish.png" width=100% height=100%> 

✔ AVAILABLE FEATURES:<br/>
- Allows logging with different levels of severity.
- Use the 'Check' method to perform all validations before writing the log.
- Use the 'Write' method to write logs to the file.
- The 'GetCallingMethodName' method allows identifying the name of the calling method at different levels of the call stack.
- Old logs can be automatically deleted through the initial check method ('Check').
- Use the 'LevelStack' property to define the maximum level to be considered in the method stack.
- The 'LogPath' property represents the location and file where the log should be recorded.
- 'LogLevel' represents the minimum level of log to be recorded in the file.
- More features coming soon.

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
                LoggingHelper.Check();
                LoggingHelper.Write("This is a this is a trace log message.", 0, "Start application.");
                LoggingHelper.Write("Debug message.", 1, null);
                LoggingHelper.Write("This is a message for an information log.", 2, null);                
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
<img src="LoggingHelper\Images\Example.png" width=100% height=100%> 

