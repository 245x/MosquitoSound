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

using System.Windows.Threading;
using System.Windows.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace MosquitoSound2
{
    public partial class MainPage : PhoneApplicationPage
    {
        private SoundEffect media10kHz;
        private SoundEffectInstance media10kHzInstance;

        private SoundEffect media12kHz;
        private SoundEffectInstance media12kHzInstance;

        private SoundEffect media14kHz;
        private SoundEffectInstance media14kHzInstance;

        private SoundEffect media15kHz;
        private SoundEffectInstance media15kHzInstance;
        
        private SoundEffect media16kHz;
        private SoundEffectInstance media16kHzInstance;

        private SoundEffect media18kHz;
        private SoundEffectInstance media18kHzInstance;
        
        private SoundEffect media20kHz;
        private SoundEffectInstance media20kHzInstance;

        // コンストラクター
        public MainPage()
        {
            InitializeComponent();

            LoadSoundInstance("Sounds/10000.wav", out media10kHz, out media10kHzInstance);
            LoadSoundInstance("Sounds/12000.wav", out media12kHz, out media12kHzInstance);
            LoadSoundInstance("Sounds/14000.wav", out media14kHz, out media14kHzInstance);
            LoadSoundInstance("Sounds/15000.wav", out media15kHz, out media15kHzInstance);
            LoadSoundInstance("Sounds/16000.wav", out media16kHz, out media16kHzInstance);
            LoadSoundInstance("Sounds/18000.wav", out media18kHz, out media18kHzInstance);
            LoadSoundInstance("Sounds/20000.wav", out media20kHz, out media20kHzInstance);

            DispatcherTimer XnaDispatchTimer = new DispatcherTimer();
            XnaDispatchTimer.Interval = TimeSpan.FromMilliseconds(50);

            XnaDispatchTimer.Tick += delegate { try { FrameworkDispatcher.Update(); } catch { } };

            XnaDispatchTimer.Start();
        }

        private void LoadSoundInstance(String SoundFilePath, out SoundEffect Sound, out SoundEffectInstance SoundInstance)
        {
            // For error checking, assume we'll fail to load the file.
            Sound = null;
            SoundInstance = null;

            try
            {
                // Holds informations about a file stream.
                StreamResourceInfo SoundFileInfo = App.GetResourceStream(new Uri(SoundFilePath, UriKind.Relative));

                // Create the SoundEffect from the Stream
                Sound = SoundEffect.FromStream(SoundFileInfo.Stream);


                SoundInstance = Sound.CreateInstance();
            }
            catch (NullReferenceException)
            {
                // Display an error message
                MessageBox.Show("Couldn't load sound " + SoundFilePath);
            }
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
                if (MessageBox.Show("現在再生している音楽を停止してもよろしいですか？", "確認", MessageBoxButton.OKCancel) == MessageBoxResult.OK) {
                    canPlay = true;
                }
            }

            if (!canPlay) {
                NavigationService.GoBack();
            }
        }

        
        private void allMediaStop(int i) {
            
            if (i != 1 && media10kHzInstance.State == SoundState.Playing) {
                media10kHzInstance.Stop();
            }

            if (i != 2 && media12kHzInstance.State == SoundState.Playing)
            {
                media12kHzInstance.Stop();
            }

            if (i != 3 && media14kHzInstance.State == SoundState.Playing)
            {
                media14kHzInstance.Stop();
            }

            if (i != 4 && media15kHzInstance.State == SoundState.Playing)
            {
                media15kHzInstance.Stop();
            }

            if (i != 5 &&media16kHzInstance.State == SoundState.Playing)
            {
                media16kHzInstance.Stop();
            }

            if (i != 6 && media18kHzInstance.State == SoundState.Playing)
            {
                media18kHzInstance.Stop();
            }

            if (i != 7 && media20kHzInstance.State == SoundState.Playing)
            {
                media20kHzInstance.Stop();
            }
        }
        

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            allMediaStop(1);
            if (media10kHzInstance.State == SoundState.Playing)
            {
                media10kHzInstance.Stop();
            }
            else {
                media10kHzInstance.Play();
            }
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            allMediaStop(2);
            if (media12kHzInstance.State == SoundState.Playing)
            {
                media12kHzInstance.Stop();
            }
            else
            {
                media12kHzInstance.Play();
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            allMediaStop(3);
            if (media14kHzInstance.State == SoundState.Playing)
            {
                media14kHzInstance.Stop();
            }
            else
            {
                media14kHzInstance.Play();
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            allMediaStop(4);
            if (media15kHzInstance.State == SoundState.Playing)
            {
                media15kHzInstance.Stop();
            }
            else
            {
                media15kHzInstance.Play();
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            allMediaStop(5);
            if (media16kHzInstance.State == SoundState.Playing)
            {
                media16kHzInstance.Stop();
            }
            else
            {
                media16kHzInstance.Play();
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            allMediaStop(6);
            if (media18kHzInstance.State == SoundState.Playing)
            {
                media18kHzInstance.Stop();
            }
            else
            {
                media18kHzInstance.Play();
            }
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            allMediaStop(7);
            if (media20kHzInstance.State == SoundState.Playing)
            {
                media20kHzInstance.Stop();
            }
            else
            {
                media20kHzInstance.Play();
            }
        }
        #region multiple MediaElement ver
        /*

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

        #region mediaCurrentStateChangedEvent

        private void media10kHzCurrentStateChangedEvent(object sender, RoutedEventArgs e)
        {
            button1.Content = media10kHz.CurrentState.ToString();
        }

        private void media12kHzCurrentStateChangedEvent(object sender, RoutedEventArgs e)
        {
            button2.Content = media12kHz.CurrentState.ToString();
        }

        private void media14kHzCurrentStateChangedEvent(object sender, RoutedEventArgs e)
        {
            button3.Content = media14kHz.CurrentState.ToString();
        }

        private void media15kHzCurrentStateChangedEvent(object sender, RoutedEventArgs e)
        {
            button4.Content = media15kHz.CurrentState.ToString();
        }

        private void media16kHzCurrentStateChangedEvent(object sender, RoutedEventArgs e)
        {
            button5.Content = media16kHz.CurrentState.ToString();
        }

        private void media18kHzCurrentStateChangedEvent(object sender, RoutedEventArgs e)
        {
            button6.Content = media18kHz.CurrentState.ToString();
        }

        private void media20kHzCurrentStateChangedEvent(object sender, RoutedEventArgs e)
        {
            button7.Content = media20kHz.CurrentState.ToString();
        }

        #endregion
        */
        #endregion
    }
}