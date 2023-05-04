using System;
using System.Threading.Tasks;
using Android.Media;
using Project3.AudioManager;
using Project3.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioPlayerService))]
namespace Project3.Droid
{
    public class AudioPlayerService :IAudioPlayerService
    {
        private MediaPlayer _mediaPlayer;
        public Action OnFinishedPlaying { get; set; }
        int maxVolume = 100;
        public AudioPlayerService()
        {
        }

        //[Obsolete]
        public void Play(string pathToAudioFile)
        {
            if (_mediaPlayer != null)
            {
                _mediaPlayer.Completion -= MediaPlayer_Completion;
                _mediaPlayer.Stop();
            }

            var fullPath = pathToAudioFile;

            Android.Content.Res.AssetFileDescriptor afd = null;

            try
            {
                afd = Android.App.Application.Context.Assets.OpenFd(fullPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error openfd: " + ex);
            }
            if (afd != null)
            {
                System.Diagnostics.Debug.WriteLine("Length " + afd.Length);
                if (_mediaPlayer == null)
                {
                    _mediaPlayer = new MediaPlayer();
                    _mediaPlayer.Prepared += (sender, args) =>
                    {
                        _mediaPlayer.Start();
                        _mediaPlayer.Completion += MediaPlayer_Completion;
                    };
                }

                _mediaPlayer.Reset();
                float log1 = (float)(Math.Log(maxVolume - 30) / Math.Log(maxVolume));
                _mediaPlayer.SetVolume(log1, log1);

                _mediaPlayer.SetDataSource(afd.FileDescriptor, afd.StartOffset, afd.Length);
                _mediaPlayer.PrepareAsync();
            }
        }

        void MediaPlayer_Completion(object sender, EventArgs e)
        {
            OnFinishedPlaying?.Invoke();
        }

        public void Pause()
        {
            _mediaPlayer?.Pause();
        }

        public void Play()
        {
             _mediaPlayer?.Start();
        }

    }
}
