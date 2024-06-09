using UnityEngine;

namespace NebulousTrinket
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioSource AudioSource;
        public void Play(SoundData soundData)
        {
            if (!soundData.Loop)
            {
                AudioSource.PlayOneShot(soundData.AudioClip, soundData.Volume);
            }
            else
            {
                AudioSource.clip = soundData.AudioClip;
                AudioSource.loop = soundData.Loop;
                AudioSource.Play();
            }
        }
    }
}
