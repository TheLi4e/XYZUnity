using Scripts.Model.Data.Properties;
using System;
using UnityEngine;

namespace Scripts.Model.Data
{
    [CreateAssetMenu(menuName = "Data/GameSettigns", fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private FloatPersistentProperty Music;
        [SerializeField] private FloatPersistentProperty Sfx;

        private static GameSettings _instance;
        public static GameSettings Instance => _instance == null ? LoadGameSettings() : _instance;

        private static GameSettings LoadGameSettings()
        {
            return _instance =  Resources.Load<GameSettings>("GameSeetings");
        }

        private void OnEnable()
        {
            Music = new FloatPersistentProperty(1, SoundSetting.Music.ToString());
            Sfx = new FloatPersistentProperty(1, SoundSetting.Sfx.ToString());
        }
    }

    public enum SoundSetting
    {
        Music,
        Sfx
    }
}
