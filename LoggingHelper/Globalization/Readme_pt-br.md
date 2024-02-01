[![NuGet](https://img.shields.io/nuget/v/LoggingHelper.svg)](https://www.nuget.org/packages/LoggingHelper/)

<img src="https://raw.githubusercontent.com/stevenrskelton/flag-icon/master/png/16/country-4x3/us.png" width=2.0% height=2.0%> See the documentation in English by [clicking here](../../Readme.md).<br/>

# LoggingHelper
Biblioteca para fácil registro de logs.<br/>

<img src="..\Images\LoggingHelper_publish.png" width=100% height=100%><br/>


## RECURSOS DISPONÍVEIS:<br/>
✔ Permite o registro de logs com diferentes níveis de gravidade;<br/>
✔ Use o método `Write` para escrever logs;<br/>
✔ Registre logs no formato que desejar personalizando `FormatLogOutput`;<br/>
✔ Use a propriedade `LevelStack` para definir o nível máximo a ser considerado na pilha de métodos;<br/>
✔ A propriedade `LogValidity` permite definir o tempo máximo (em dias) para o arquivo de log ser resetado;<br/>
✔ `LogLevelFile` representa o nível mínimo de log a ser registrado no arquivo;<br/>
✔ A propriedade `LogPathFile` define o local e o arquivo onde o log deve ser registrado;<br/>
✔ `LogLevelConsole` define o nível mínimo de log a ser registrado no console;<br/>
✔ Altere o enum `Level` para personalizar os níveis de log;<br/>
✔ Defina o nível do log utilizando enumeração, número ou texto;<br/>
✔ Use o método `CheckFile` para ocultar o diretório de log e realizar validações;<br/>
✔ `GetCallingMethodName` permite identificar o método que registrou o log considerando o nível da pilha;<br/>
✔ Arquivos de logs antigos podem ser automaticamente excluídos por meio do método de verificação (`CheckFile`);<br/> 
✔ Mais recursos em breve.<br/>

<br/><br/>

## FEEDBACK:
https://bit.ly/FeedbackHappyHelper

<br/><br/>

## INSTALAÇÃO:
```
 dotnet add package LoggingHelper --version 1.2.0
```

<br/><br/>

## EXEMPLO DE USO
### Código:
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
                // Opcional
                //LoggingHelper.CheckFile(2, false);
                //LoggingHelper.FormatLogOutput = "[<level>] <yyyy-MM-dd HH:mm:ss.fff> (<stack>) <message> | <obs>";
                //LoggingHelper.LevelStack = 3;
                //LoggingHelper.LogValidity = 2;

                //LoggingHelper.LogPathFile = @".\LOG_TEST\Logging_general.log";
                //LoggingHelper.LogLevelFile = 0;
                //LoggingHelper.LogLevelConsole = 0;

                LoggingHelper.Write("Esta é uma mensagem de log de rastreamento.", 0, "Iniciar app.");
                LoggingHelper.Write("Mensagem de depuração.", 1, null);
                LoggingHelper.Write("Esta é uma mensagem para um log de informação [2].", 2, null);
                LoggingHelper.Write("Esta é também uma mensagem para um log de informação [3].", LoggingHelper.Level.INFO, null);
                LoggingHelper.Write("Esta é também uma mensagem para um log de informação [4].", "INFO", null);
                LoggingHelper.Write("Esta é também uma mensagem para um log de informação [5].", "2", null);

                throw new Exception();
            }
            catch (Exception ex)
            {
                LoggingHelper.Write("Esta é uma mensagem de log para registrar erros!", 4, ex.Message);
            }           
        }
    }
}

```


### Resultado:
```console
01/02/2024 14:19:18.483 [TRACE] (/Main) Esta é uma mensagem de log de rastreamento. | Iniciar app.
01/02/2024 14:19:18.486 [DEBUG] (/Main) Mensagem de depuração.
01/02/2024 14:19:18.486 [INFO] (/Main) Esta é uma mensagem para um log de informação [2].
01/02/2024 14:19:18.487 [INFO] (/Main) Esta é também uma mensagem para um log de informação [3].
01/02/2024 14:19:18.488 [INFO] (/Main) Esta é também uma mensagem para um log de informação [4].
01/02/2024 14:19:18.488 [INFO] (/Main) Esta é também uma mensagem para um log de informação [5].
01/02/2024 14:19:18.489 [ERROR] (/Main) Esta é uma mensagem de log para registrar erros! | Exception of type 'System.Exception' was thrown.
```