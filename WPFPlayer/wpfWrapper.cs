using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFPlayer
{
    class wpfWrapper
    {
        MediaElement player;
        MainWindow window;
        public wpfWrapper(MainWindow windowHandle, MediaElement player) {
            this.player = player;
            window = windowHandle;
        }
        public void Open(Uri path, bool autoRun) {
            player.Source = path;
            if (autoRun)
                Play();
        }
        public void Open(Uri path) { 
            Open(path, true);
        }
        public void Open(string path, bool autoRun) { 
            Open(new Uri(path, UriKind.RelativeOrAbsolute), autoRun); 
        }
        public void Open(string path) {
            Open(new Uri(path, UriKind.RelativeOrAbsolute), true);
        }
        public void Play() {
            if (player.Source != null) player.Play();
        }
        public void Pause() {
            if (player.Source != null) player.Pause();
        }
        public void Stop() {
            if (player.Source != null) player.Stop();
        }
        public void SetFullscreen(bool fullscreen) {
            if (player.Source != null)
            {
                if (fullscreen)
                {
                    window.WindowStyle = WindowStyle.None;
                    window.WindowState = WindowState.Maximized;
                }
                else
                {
                    window.WindowStyle = WindowStyle.SingleBorderWindow;
                    window.WindowState = WindowState.Normal;
                }
            }
        }
        public double GetPosition() {
            if (player.Source != null && player.NaturalDuration.HasTimeSpan)
                return player.Position.TotalSeconds;
            return -1;
        }
        public void SetPosition(int position) {
            if (player.Source != null)
                player.Position = new TimeSpan(0, 0, position);
        }
        public double GetVolume() {
            return player.Volume * 100;
        }
        public void SetVolume(double volume) {
            player.Volume = volume / 100;
        }
        public double GetBalance() {
            return player.Balance * 100;
        }
        public void SetBalance(double balance) {
            player.Balance = balance / 100;
        }
        public double GetDuration() {
            if (player.NaturalDuration.HasTimeSpan)
                return player.NaturalDuration.TimeSpan.TotalSeconds;
            else
                return 0;
        }

    }
}
