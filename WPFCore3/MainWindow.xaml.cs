using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Serilog;

namespace WPFCore3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainVM VM { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = VM = new MainVM();

            //VM.MessageBoxIt = new OperationCommand(msg =>
            //{
            //    MessageBox.Show(msg.ToString(), "Certifying", MessageBoxButton.OK, MessageBoxImage.Information);
            //});

            (AppDomain.CurrentDomain).UnhandledException += (s, e) =>
                LogUnhandledException(e.ExceptionObject as Exception, nameof(AppDomain.CurrentDomain));

            if (Dispatcher != null)
                Dispatcher.UnhandledException += (s, e) =>
                {
                    LogUnhandledException(e.Exception, nameof(Dispatcher));
                    e.Handled = false;
                };

            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                LogUnhandledException(e.Exception, nameof(TaskScheduler));
                e.SetObserved();
            };

            // Do this last to avoid binding errors
            InitializeComponent();

        }

        private void LogUnhandledException(Exception exception, string v)
        {

 //           var jsonString = JsonSerializer.Serialize(exception);

            Log.Fatal(exception, v);
            //CertifyingVM.SafeOperationToGuiThread(() =>
            //{
            //    VM.Error = $" Error ({v}): {exception.Message}";
            //});

            //Trace.WriteLine($"({nameof(Certifying)}) Unhandled Exception : {VM.Error}");

            //VM.CommandWriteCrashDump.Execute(exception.CreateReadableException());
            ////File.WriteAllText("crash.dmp", exception.CreateReadableException());
        }

    }
}
