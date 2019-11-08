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
using System.Windows.Threading;

namespace WPFPlayer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        wpfWrapper wpf;
        bool fullScreen;
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            wpf = new wpfWrapper(this, wpfpanel);
            balSlider.Value = 50;
            volSlider.Value = 20;
            fullScreen = false;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += onTimerTick;
            timer.Start();
        }

        void onTimerTick(object sender, EventArgs e)
        {
            sliderTime.Maximum = wpf.GetDuration();
            if (Mouse.LeftButton != MouseButtonState.Pressed)
            {
                // only update, if user is currently not dragging the slider
                double newValue = wpf.GetPosition();
                if (newValue != -1)
                {
                    sliderTime.Value = newValue;
                    lblStatus.Content = String.Format("{0:00}:{1:00} / {2:00}:{3:00}",
                    (int)newValue / 60, (int)newValue % 60,
                    (int)wpf.GetDuration() / 60,
                    (int)wpf.GetDuration() % 60);
                }
                else
                    lblStatus.Content = "No file selected...";
            }
        }

        /*private void setFullScreen(bool fullscreen)
        {
            if (fullscreen)
            {
                wpfpanel.Margin = new Thickness(0, 0, 0, 0);
                wpf.SetFullscreen(true);
                uiStack.Visibility = Visibility.Collapsed;
                myWindow.Background = new SolidColorBrush(Colors.Black);
            }
            else
            {
                wpfpanel.Margin = new Thickness(0, 0, 0, 150);
                wpf.SetFullscreen(false);
                uiStack.Visibility = Visibility.Visible;
                myWindow.Background = new SolidColorBrush(Colors.White);
            }
        }
        */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TOGGLE FULLSCREEN

            fullScreen = !fullScreen;
            //setFullScreen(fullScreen);
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

        private void sliderTime_PreviewDragLeave(object sender, DragEventArgs e)
        {
            wpf.SetPosition((int)sliderTime.Value);
        }
    }
}
