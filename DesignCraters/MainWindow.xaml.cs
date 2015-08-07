using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;

namespace DesignCraters
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public static class ArrayExtensions
    {
        public static void Fill<T>(this T[] originalArray, T with)
        {
            for (int i = 0; i < originalArray.Length; i++)
            {
                originalArray[i] = with;
            }
        }
    }

    public partial class MainWindow : Window
    {

        // Create the writeable bitmap will be used to write and update.
        private static WriteableBitmap _wb =
            new WriteableBitmap(10, 300, 150, 150, PixelFormats.Bgr32, null);

        // Define the rectangle of the writeable image we will modify. 
        // The size is that of the writeable bitmap.
        private static Int32Rect _rect = new Int32Rect(0, 0, 
            _wb.PixelWidth, _wb.PixelHeight);

        // Calculate the number of bytes per pixel. 
        //байтов за пиксель
        private static int _bytesPerPixel = (_wb.Format.BitsPerPixel + 7) / 8;


        // Stride is bytes per pixel times the number of pixels.
        // Stride is the byte width of a single rectangle row.
        private static int _stride = _wb.PixelWidth * _bytesPerPixel;

        // Create a byte array for a the entire size of bitmap.
        private static int _arraySize = _stride * _wb.PixelHeight;
        private static byte[] _colorArray = new byte[_arraySize];

        public MainWindow()
        {
            InitializeComponent();

            HouseOfRooms hs = new HouseOfRooms();
            hs.createRoom(new RoomFactory(), 10, 11);

            // Define the Image element
            _random.Stretch = Stretch.None;
            _random.Margin = new Thickness(20);

            // DispatcherTimer setup
            // The DispatcherTimer will be used to update _random every
            //    second with a new random set of colors.
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.IsEnabled = true;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

        }

        //  System.Windows.Threading.DispatcherTimer.Tick handler
        //
        //  Updates the Image element with new random colors
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //Update the color array with new random colors
            Random value = new Random();
            value.NextBytes(_colorArray);

            
            byte[] _Array = new byte[_arraySize];
            //Array.Clear(_Array, 0, _arraySize);
            ArrayExtensions.Fill<byte>(_Array, 0x25);

            //Update writeable bitmap with the colorArray to the image.
            _wb.WritePixels(_rect, _Array, _stride, 0);

            //Set the Image source.
            _random.Source = _wb;

        }
    }
}
