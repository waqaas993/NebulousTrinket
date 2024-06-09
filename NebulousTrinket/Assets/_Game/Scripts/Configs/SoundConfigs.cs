using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace NebulousTrinket
{
    [CreateAssetMenu(menuName = "Configs/SoundConfigs", fileName = "SoundConfigs")]
    public class SoundConfigs : BaseConfigs
    {
        public List<SoundData> SoundDatas = new();

        public SoundData GetSoundData(string name, SoundType soundType) 
        {
            SoundData soundData = SoundDatas.Where( sd => sd.Name == name && sd.SoundType == soundType).FirstOrDefault();
            if (soundData == null) 
            {
                Debug.LogError($"Sound not found!");
            }
            return soundData;
        }
    }

    [System.Serializable]
    public class SoundData
    {
        public SoundType SoundType;
        public string Name;
        public AudioClip AudioClip;
        [Range(0f, 1f)]
        public float Volume;
        public bool Loop;
    }

    [System.Serializable]
    public enum SoundType
    {
        Music,
        SFX
    }
}
