using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Serilog;
using Serilog.Events;

namespace WPFCore3
{
    public class MainVM
    {
        #region Variables

        #endregion

        #region Properties

        public ObservableCollection<string> LogLines { get; set; }

        #endregion

        #region Construction/Initialization

        public MainVM()
        {
            LogLines = new ObservableCollection<string>();
            SetupLogging();
            Log.Information("VM Created");
        }

        #endregion

        #region Methods
        private void SetupLogging() => App.LoadLogging(SaveLog);


        public void SaveLog(LogEvent lg, string single, string json)
        {
            var msg = lg.RenderMessage();
            LogLines.Add(json);
        }
        #endregion

    }
}
