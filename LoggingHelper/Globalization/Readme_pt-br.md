[![NuGet](https://img.shields.io/nuget/v/LoggingHelper.svg)](https://www.nuget.org/packages/LoggingHelper/)

<img src="https://raw.githubusercontent.com/stevenrskelton/flag-icon/master/png/16/country-4x3/us.png" width=2.0% height=2.0%> See the documentation in English by [clicking here](../../Readme.md).<br/>

# LoggingHelper
Biblioteca para fácil registro de logs.<br/>

<img src="..\Images\LoggingHelper_publish.png" width=100% height=100%><br/>


## RECURSOS DISPONÍVEIS:<br/>
✔ Permite o registro de logs com diferentes níveis de gravidade;<br/>
✔ Use o método `Write` para escrever logs no arquivo;<br/>
✔ Use a propriedade `LevelStack` para definir o nível máximo a ser considerado na pilha de métodos;<br/>
✔ A propriedade `LogValidity` permite definir o tempo máximo (em dias) para o arquivo de log ser resetado;<br/>
✔ `LogLevel` representa o nível mínimo de log a ser registrado no arquivo;<br/>
✔ A propriedade `LogPath` define o local e o arquivo onde o log deve ser registrado;<br/>
✔ Use o método `Check` para ocultar o diretório de log;<br/>
✔ `GetCallingMethodName` permite identificar o método que registrou o log considerando o nível da pilha;<br/>
✔ Logs antigos podem ser automaticamente excluídos por meio do método de verificação inicial (`Check`);<br/> 
✔ Mais recursos em breve.<br/>

<br/><br/>

## INSTALAÇÃO:
```
 dotnet add package LoggingHelper --version 1.1.0
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
                LoggingHelper.Write("Esta é um mensagem de log de rastreamento (trace).", 0, "Início app.");
                LoggingHelper.Write("Mensagem de depuração (debug).", 1, null);
                LoggingHelper.Write("Esta é uma mensagem para um log de informação (info).", 2, null);             
                LoggingHelper.Write("Esta também é uma mensagem para um log de informação (info).", LoggingHelper.Level.INFO, null); 
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
20/08/2023 14:06:56 [TRACE] (/Main) Esta é um mensagem de log de rastreamento (trace). | Início app.
20/08/2023 14:06:56 [DEBUG] (/Main) Mensagem de depuração (debug).
20/08/2023 14:06:56 [INFO] (/Main) Esta é uma mensagem para um log de informação (info).
20/08/2023 14:06:56 [INFO] (/Main) Esta também é uma mensagem para um log de informação (info).
20/08/2023 14:06:56 [ERROR] (/Main) Esta é uma mensagem de log para registrar erros! | Exceção do tipo 'System.Exception' foi lançada.
```