namespace FiapStore.Logging
{
    internal class CustomLogger : ILogger
    {
        private string nome;
        private CustomLoggerProviderConfiguration loggerConfig;

        public CustomLogger(string nome, CustomLoggerProviderConfiguration loggerConfig)
        {
            this.nome = nome;
            this.loggerConfig = loggerConfig;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            string mensagem = $"[{DateTime.Now.ToString("yyyy//MM//dd HH:mm:ss")}] {logLevel}: {eventId} - {formatter(state, exception)}";
            EscreverTextoArquivo(mensagem);
        }
        private void EscreverTextoArquivo(string mensagem)
        {
            string caminhoLog = @"C:\\temp\\FiapStore\\Log";
            string arquivoLog =
                Path.Combine(
                    caminhoLog,
                    $"LOG-{DateTime.Today.ToString("yyyyMMdd")}.log");
            if (!Directory.Exists(caminhoLog))
            {
                Directory.CreateDirectory(caminhoLog);
            }

            using StreamWriter streamWriter = new(arquivoLog, true);
            streamWriter.WriteLine(mensagem);
            streamWriter.Close();
        }
    }
}