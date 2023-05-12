using System;
using UnityEngine;

namespace Demicus.Code.Infrastructure.Saving
{
    [Serializable]
    public class PlayerSettings
    {
        [SerializeField] public float soundVolume;
        [SerializeField] public float musicVolume;
        [SerializeField] public float ambienceVolume;
        [SerializeField] public float sfxVolume;

        public PlayerSettings()
        {
            soundVolume = 1;
            musicVolume = 1;
            ambienceVolume = 1;
            sfxVolume = 1;
        }
    }
}