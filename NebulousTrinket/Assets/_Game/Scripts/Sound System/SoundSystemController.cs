using UnityEngine;
using UnityEngine.Audio;

namespace NebulousTrinket
{
    public class SoundSystemController : BaseController
    {
        private SoundSystemModel Model;

        [SerializeField]
        private AudioMixer AudioMixer;

        [Header("Players")]
        [SerializeField]
        private AudioPlayer MusicPlayer;
        [SerializeField]
        private AudioPlayer SFXPlayer;

        public override void Initialize(params object[] parameters)
        {
            Model = new();
        }

        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }

        private void Play(string sound, SoundType soundType)
        {
            SoundData soundData = GetSoundData(sound, soundType);
            switch (soundType)
            {
                case SoundType.Music:
                    MusicPlayer.Play(soundData);
                    break;
                case SoundType.SFX:
                    MusicPlayer.Play(soundData);
                    break;
                default:
                    break;
            }
        }

        private SoundData GetSoundData(string sound, SoundType soundType) => Model.GetSoundData(sound, soundType);
    }
}