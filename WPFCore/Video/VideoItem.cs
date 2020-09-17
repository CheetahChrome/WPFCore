using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WPFCore.Video
{
    class VideoItem
    {

        public string FileName { get; set; }

        public BitmapImage Image { get; set; }

        public VideoItem(string name)
        {
            FileName = name;

            ShellFile shellFile = ShellFile.FromFilePath(FileName);
            Bitmap bm = shellFile.Thumbnail.Bitmap;

            Image = ConvertBitmapToBitmapImage(bm);


        }


        public static BitmapImage ConvertBitmapToBitmapImage(Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();

            return image;
        }

    }
}
