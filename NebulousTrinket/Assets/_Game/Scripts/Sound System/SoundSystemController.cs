using System;
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
            Play(SoundConsts.BACKGROUND_MUSIC, SoundType.Music);
        }

        private void OnEnable()
        {
            FaceCardController.OnFlip += CardFlipped;
            GamePlayController.OnCardMatched += CardMatched;
            GamePlayController.OnCardsUnmatched += CardsUnmatched;
        }

        private void OnDisable()
        {
            FaceCardController.OnFlip -= CardFlipped;
            GamePlayController.OnCardMatched -= CardMatched;
            GamePlayController.OnCardsUnmatched -= CardsUnmatched;
        }

        private void CardFlipped(FaceCardController faceCardController) => Play(SoundConsts.CARD_FLIPPED, SoundType.SFX);
        private void CardMatched(string obj) => Play(SoundConsts.CARD_MATCHED, SoundType.SFX);
        private void CardsUnmatched(string arg1, string arg2) => Play(SoundConsts.CARD_UNMATCHED, SoundType.SFX);

        private void Play(string sound, SoundType soundType)
        {
            SoundData soundData = GetSoundData(sound, soundType);
            switch (soundType)
            {
                case SoundType.Music:
                    MusicPlayer.Play(soundData);
                    break;
                case SoundType.SFX:
                    SFXPlayer.Play(soundData);
                    break;
                default:
                    break;
            }
        }

        private SoundData GetSoundData(string sound, SoundType soundType) => Model.GetSoundData(sound, soundType);
    }
}