using System;
using System.Collections.Generic;
using System.Text;

namespace WPFCore3.Models
{
    public class LogEmit
    {
        public string Timestamp { get; set; }

        public string Level { get; set; }

        public string MessageTemplate { get; set; }

        public string RenderedMessage { get; set; }

        public string Exception { get; set; }

        public Properties Properties { get; set; }

    }

    public class Properties
    {
        public ExceptionDetail ExceptionDetail { get; set; }

    }


    public class ExceptionDetail
    {
        public Data Data { get; set; }

        public int HResult { get; set; }

        public string Message { get; set; }

        public string Source { get; set; }

        public InnerException InnerException { get; set; }

        public int LineNumber { get; set; }

        public int LinePosition { get; set; }

        public string KeyContext { get; set; }

        public string UidContext { get; set; }

        public string NameContext { get; set; }

        public string BaseUri { get; set; }

        public string Type { get; set; }

    }


    public class Data
    {
  //      public string System.Object { get; set; }

    }


    public class InnerException
    {
        public string Type { get; set; }

        public int HResult { get; set; }

        public string Message { get; set; }

        public string Source { get; set; }

    }


}
