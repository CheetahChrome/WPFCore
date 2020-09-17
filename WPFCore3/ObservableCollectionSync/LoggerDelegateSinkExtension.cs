using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Formatting;

namespace WPFCore3.ObservableCollectionSync
{
    public static class LoggerDelegateSinkExtension
    {
        public static LoggerConfiguration ObservableCollection(this LoggerSinkConfiguration loggerConfig,  
                                                               Action<LogEvent, string, string> handler,
                                                               ITextFormatter lineFormat = null,
                                                               ITextFormatter jsonFormat = null) 
            => loggerConfig.Sink(new ObservableCollectionDelegateSink(handler, lineFormat, jsonFormat));
    }
}
