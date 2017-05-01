using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using MjpegProcessor;
using ZXing;
using System.Drawing;
using System.IO;

namespace Employee_Resources_Manage
{
    /// <summary>
    /// Interaction logic for QRCode.xaml
    /// </summary>
    public partial class QRCode : UserControl
    {
        System.Windows.Threading.DispatcherTimer scanTimer;
        MjpegDecoder mjd;

        public QRCode()
        {
            InitializeComponent();
            scanTimer = new System.Windows.Threading.DispatcherTimer();
            scanTimer.Tick += scanTimer_Tick;
            scanTimer.Interval = new TimeSpan(0, 0, 1);
            mjd = new MjpegDecoder();
            mjd.FrameReady += Mjd_FrameReady;
        }

        private void Mjd_FrameReady(object sender, FrameReadyEventArgs e)
        {
            CameraScreen.Source = e.BitmapImage;
        }

        private void scanTimer_Tick(object sender, EventArgs e)
        {
            if (CameraScreen.Source != null)
            {
                System.Drawing.Bitmap bitmap;
                using (MemoryStream outStream = new MemoryStream())
                {
                    BitmapEncoder enc = new BmpBitmapEncoder();
                    enc.Frames.Add(BitmapFrame.Create((BitmapImage)CameraScreen.Source));
                    enc.Save(outStream);
                    bitmap = new System.Drawing.Bitmap(outStream);
                }

                ZXing.BarcodeReader Reader = new ZXing.BarcodeReader();
                Result result = Reader.Decode((Bitmap)bitmap);

                try
                {
                    string decoded = result.ToString().Trim();
                    if (decoded != "")
                    {
                        scanTimer.Stop();
                        MessageBox.Show(decoded);
                    }

                }
                catch (Exception ex)
                { }
            }
        }

        bool streamOn = false;
        private void StreamQRCode_Click(object sender, RoutedEventArgs e)
        {
            scanTimer.Start();
            if (streamOn == false)
                mjd.ParseStream(new Uri("http://192.168.1.2:4747/mjpegfeed?640x480"));
            streamOn = true;
        }
    }
}
