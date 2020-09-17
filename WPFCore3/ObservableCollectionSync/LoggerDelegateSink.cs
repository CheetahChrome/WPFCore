using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;

namespace WPFCore3.ObservableCollectionSync
{
    public class ObservableCollectionDelegateSink : ILogEventSink
    {
        private ITextFormatter SingleLineProvider { get; set; }
        private ITextFormatter JsonProvider { get; set; }
        private Action<LogEvent, string, string> Operation { get; set; }



        public ObservableCollectionDelegateSink(Action<LogEvent, string, string> handler, 
                                                ITextFormatter singleLineProvider = null, 
                                                ITextFormatter jsonProvider = null)
        {
            SingleLineProvider = singleLineProvider;
            JsonProvider = jsonProvider;
            //      _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
            Operation = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        public void Emit(LogEvent logEvent)
        {
            if (Operation == null)
                return;

            //if (Provider == null)
            //    Operation?.Invoke(logEvent);
            //else
            //{
            //    var message = logEvent.RenderMessage(Provider);
            ////     Operation?.Invoke(message);
            /// 
            var buffer = new StringWriter(new StringBuilder());
            SingleLineProvider.Format(logEvent, buffer);
            //   Operation(buffer.ToString());

            var json = new StringWriter(new StringBuilder());
            JsonProvider.Format(logEvent, json);

            Operation(logEvent, buffer.ToString(), json.ToString());
          //  }
        }
    }
}
