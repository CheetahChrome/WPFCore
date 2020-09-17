using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFCore.Video;

namespace WPFCore.VM
{
    internal class MainVM : INotifyPropertyChanged
    {

        #region Variables

        #endregion

        #region Properties

        private List<VideoItem> _Videos;

        public List<VideoItem> Videos
        {
            get { return _Videos; }
            set { _Videos = value; OnPropertyChanged(nameof(Videos)); }
        }
        #endregion

        #region Construction/Initialization

        #endregion

        #region Methods


        public ICommand CommandWriteCrashDump => new OperationCommand((msg) =>{ File.WriteAllText("crash.dmp", (string)msg); } ); //End of Crashdump

        public ICommand LoadFilesCMD => new OperationCommand(LoadFiles);

        public void LoadFiles(object obj)
        {
            var v2 = @"F:\Backup\Moving\JDownloader\Asian.EmberSnow.EroticaX.18.09.12.Ember.Snow.Not.So.Merry.Widow.XXX.1080p.mp4";


            var v1 = @"F:\Backup\Moving\JDownloader\AngelaWhite.mp18103001.mp4";

            Videos = new List<VideoItem>()
            {
                new VideoItem(v2),
                new VideoItem(v1)
            };


        }
        /// <summary>
        /// Event raised when a property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion

    }
}
