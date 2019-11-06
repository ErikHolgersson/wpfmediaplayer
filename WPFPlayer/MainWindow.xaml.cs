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

namespace WPFPlayer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        wpfWrapper wpf;
        bool fullScreen;
        public MainWindow()
        {
            InitializeComponent();
            wpf = new wpfWrapper(this, wpfpanel);
            fullScreen = false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TOGGLE FULLSCREEN

            fullScreen = !fullScreen;
            wpf.SetFullscreen(fullScreen);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //PLAY
            wpf.SetVolume(volSlider.Value);
            wpf.SetBalance(balSlider.Value);
            wpfpanel.Play();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //OPEN
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                wpf.Open(ofd.FileName);
                this.Title = ofd.SafeFileName;
                sliderTime.Maximum = wpf.GetDuration();
            }

        }

        private void btn_pause_Click(object sender, RoutedEventArgs e)
        {
            //PAUSE
            wpfpanel.Pause();
        }

        private void btn_stop_Click(object sender, RoutedEventArgs e)
        {
            //STOP
            wpfpanel.Close();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            wpf.SetVolume(e.NewValue);
        }

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            wpf.SetBalance(e.NewValue);
        }
    }
}
