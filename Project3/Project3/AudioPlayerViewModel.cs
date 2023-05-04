using System;
using System.ComponentModel;
using System.Windows.Input;
using Project3.AudioManager;
using Xamarin.Forms;

namespace Project3
{
    public class AudioPlayerViewModel
    {

        public AudioPlayerViewModel()
        {
            var audioPlayer = DependencyService.Get<IAudioPlayerService>();
            _audioPlayer = audioPlayer;
            _audioPlayer.OnFinishedPlaying = () => {
                _isStopped = true;
                CommandText = "Play";
            };
            CommandText = "Play";
            _isStopped = true;
            PlayPauseCommand = new Command(PlayPauseCommandAsync);
        }

        public void PlayPauseCommandAsync(object obj)
        {
            if (CommandText == "Play")
            {
                if (_isStopped)
                {
                    _isStopped = false;
                    _audioPlayer.Play("Galway.mp3");
                }
                else
                {
                    _audioPlayer.Play();
                }
                CommandText = "Pause";
            }
            else
            {
                _audioPlayer.Pause();
                CommandText = "Play";
            }
        }

        private string _commandText;
        public string CommandText
        {
            get { return _commandText; }
            set
            {
                _commandText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CommandText"));
            }
        }
        public ICommand _playPauseCommand;
        public ICommand PlayPauseCommand
        { get; set; }

        public IAudioPlayerService _audioPlayer { get; set; }
        public bool _isStopped;
        public event PropertyChangedEventHandler PropertyChanged;
    
    }
}
