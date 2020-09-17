using Serilog;
using Serilog.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Serilog.Events;
using Serilog.Formatting.Json;
using WPFCore3.ObservableCollectionSync;
using Serilog.Formatting;

namespace WPFCore3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App(){}

        public static void LoadLogging(Action<LogEvent, string, string> handler)
        {

            //     Serilog.Formatting.Display.MessageTemplateTextFormatter tf = new Serilog.Formatting.Display.MessageTemplateTextFormatter(outputTemplate, CultureInfo.InvariantCulture);

            // Install-Package Serilog.Enrichers.Demystify -Pre -DependencyVersion Highest 

            ITextFormatter jsonFormatter = new JsonFormatter(renderMessage: true);

            var outputTemplate = "[{Timestamp:mm:ss}]-[{Level:u3}] {Message:lj} {Exception}";
            var tf = new Serilog.Formatting.Display.MessageTemplateTextFormatter(outputTemplate, CultureInfo.InvariantCulture);


            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Debug()
                                .Enrich.FromLogContext()                // Enables class/function name in logs
                                .Enrich.WithExceptionDetails()         // Enables full exception information
                                .Enrich.WithDemystifiedStackTraces()  // Enables a more readable stack trace (Serilog.Enrichers.Demystify)
                    //            .Enrich.WithCaller()
                                .WriteTo.Trace()                     // Enables VS console logging
                                .WriteTo.ObservableCollection(handler, tf, jsonFormatter)
                                .WriteTo.RollingFile(jsonFormatter, string.Empty)
                                .CreateLogger();


    //        Logger.CreateLogger(configRoot, directories.AppLogDir, ShowLogMessage);


            Log.Information("Started");
        }
    }
}
