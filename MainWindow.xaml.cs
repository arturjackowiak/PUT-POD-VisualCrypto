using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Visual_Crypto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bitmap[] dividedImage = new Bitmap[2];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "All Files (*.*)|*.*",
                RestoreDirectory = true
            };

            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                InputImage.Source = bitmap;

                dividedImage = CryptoService.GenerateDivisions(bitmap.ToBitmap());

                Division1Image.Source = dividedImage[0].ToBitmapImage();
                Division2Image.Source = dividedImage[1].ToBitmapImage();

                var mergedImage = CryptoService.MergeImages(dividedImage);

                OutputImage.Source = mergedImage.ToBitmapImage();

                //dividedImage[0].Save("Division 1.png");
                //dividedImage[1].Save("Division 2.png");

                mergedImage.Save("Result.png");
            }
        }
    }
}
