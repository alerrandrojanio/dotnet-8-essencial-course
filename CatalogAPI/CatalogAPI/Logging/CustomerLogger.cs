namespace APICatalogo.Logging;

public class CustomerLogger : ILogger
{
    readonly string loggerName;

    readonly CustomLoggerProviderConfiguration loggerConfig;

    public CustomerLogger(string name, CustomLoggerProviderConfiguration config)
    {
        loggerName = name;
        loggerConfig = config;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel == loggerConfig.LogLevel;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception exception, Func<TState, Exception, string> formatter)
    {
        string mensagem = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";

        writeText(mensagem);
    }

    private void writeText(string logMessage)
    {
        string filePath = @"C:\Users\Public\DocumentsLog.txt";
        
        using (StreamWriter streamWriter = new StreamWriter(filePath, true))
        {
            try
            {
                streamWriter.WriteLine(logMessage);
                streamWriter.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}