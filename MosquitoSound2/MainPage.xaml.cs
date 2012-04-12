using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace MosquitoSound2
{
    public partial class MainPage : PhoneApplicationPage
    {
        // コンストラクター
        public MainPage()
        {
            InitializeComponent();
        }

        
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            bool canPlay = false;

            FrameworkDispatcher.Update();

            if (MediaPlayer.GameHasControl)
            {
                canPlay = true;
            }
            else {
                if (MessageBox.Show("現在再生している音楽を停止してもよろしいですか？", "音楽を再生中です", MessageBoxButton.OKCancel) == MessageBoxResult.OK) {
                    canPlay = true;
                }
            }

            if (!canPlay) {
                NavigationService.GoBack();
            }
        }

        #region button_Click

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            switch (media10kHz.CurrentState) { 
                case MediaElementState.Stopped:
                    media10kHz.Play();
                    button1.Content = "Playing";
                    break;
                case MediaElementState.Paused:
                    media10kHz.Play();
                    button1.Content = "Playing";
                    break;
                case MediaElementState.Playing:
                    media10kHz.Stop();
                    button1.Content = "10kHz";
                    break;
                case MediaElementState.Closed:
                    button1.Content = "Closed";
                    break;
                case MediaElementState.Buffering:
                    button1.Content = "Buffering";
                    break;
                default:
                    button1.Content = media10kHz.CurrentState.ToString();
                    break;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            switch (media12kHz.CurrentState)
            {
                case MediaElementState.Stopped:
                case MediaElementState.Paused:
                    media12kHz.Play();
                    button2.Content = "Playing";
                    break;
                case MediaElementState.Playing:
                    media12kHz.Stop();
                    button2.Content = "12kHz";
                    break;
                default:
                    button2.Content = media12kHz.CurrentState.ToString();
                    break;
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            switch (media14kHz.CurrentState)
            {
                case MediaElementState.Stopped:
                case MediaElementState.Paused:
                    media14kHz.Play();
                    button3.Content = "Playing";
                    break;
                case MediaElementState.Playing:
                    media14kHz.Stop();
                    button3.Content = "14kHz";
                    break;
                default:
                    button3.Content = media14kHz.CurrentState.ToString();
                    break;
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            switch (media15kHz.CurrentState)
            {
                case MediaElementState.Stopped:
                case MediaElementState.Paused:
                    media15kHz.Play();
                    button4.Content = "Playing";
                    break;
                case MediaElementState.Playing:
                    media15kHz.Stop();
                    button4.Content = "15kHz";
                    break;
                default:
                    button4.Content = media15kHz.CurrentState.ToString();
                    break;
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            switch (media16kHz.CurrentState)
            {
                case MediaElementState.Stopped:
                case MediaElementState.Paused:
                    media16kHz.Play();
                    button5.Content = "Playing";
                    break;
                case MediaElementState.Playing:
                    media16kHz.Stop();
                    button5.Content = "16kHz";
                    break;
                default:
                    button5.Content = media16kHz.CurrentState.ToString();
                    break;
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            switch (media18kHz.CurrentState)
            {
                case MediaElementState.Stopped:
                case MediaElementState.Paused:
                    media18kHz.Play();
                    button6.Content = "Playing";
                    break;
                case MediaElementState.Playing:
                    media18kHz.Stop();
                    button6.Content = "18kHz";
                    break;
                default:
                    button6.Content = media18kHz.CurrentState.ToString();
                    break;
            }
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            switch (media10kHz.CurrentState)
            {
                case MediaElementState.Stopped:
                case MediaElementState.Paused:
                    media20kHz.Play();
                    button7.Content = "Playing";
                    break;
                case MediaElementState.Playing:
                    media20kHz.Stop();
                    button7.Content = "20kHz";
                    break;
                default:
                    button7.Content = media20kHz.CurrentState.ToString();
                    break;
            }
        }
        #endregion

        #region mediaCompleteEvent

        private void media10kHzCompleteEvent(object sender, ManipulationCompletedEventArgs e)
        {
            button1.Content = "10kHz";
        }

        private void media12kHzCompleteEvent(object sender, ManipulationCompletedEventArgs e)
        {
            button2.Content = "12kHz";
        }

        private void media14kHzCompleteEvent(object sender, ManipulationCompletedEventArgs e)
        {
            button3.Content = "14kHz";
        }

        private void media15kHzCompleteEvent(object sender, ManipulationCompletedEventArgs e)
        {
            button4.Content = "15kHz";
        }

        private void media16kHzCompleteEvent(object sender, ManipulationCompletedEventArgs e)
        {
            button5.Content = "16kHz";
        }

        private void media18kHzCompleteEvent(object sender, ManipulationCompletedEventArgs e)
        {
            button6.Content = "18kHz";
        }

        private void media20kHzCompleteEvent(object sender, ManipulationCompletedEventArgs e)
        {
            button7.Content = "20kHz";
        }

        #endregion

        #region mediaEndedEvent

        private void media10kHzEndedEvent(object sender, RoutedEventArgs e)
        {
            button1.Content = "10kHz";
        }

        private void media12kHzEndedEvent(object sender, RoutedEventArgs e)
        {
            button2.Content = "12kHz";
        }

        private void media14kHzEndedEvent(object sender, RoutedEventArgs e)
        {
            button3.Content = "14kHz";
        }

        private void media15kHzEndedEvent(object sender, RoutedEventArgs e)
        {
            button4.Content = "15kHz";
        }

        private void media16kHzEndedEvent(object sender, RoutedEventArgs e)
        {
            button5.Content = "16kHz";
        }

        private void media18kHzEndedEvent(object sender, RoutedEventArgs e)
        {
            button6.Content = "18kHz";
        }

        private void media20kHzEndedEvent(object sender, RoutedEventArgs e)
        {
            button7.Content = "20kHz";
        }
        #endregion
    }
}