/*! \cond PRIVATE */
using System;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace DarkTonic.MasterAudio {
    [Serializable]
    // ReSharper disable once CheckNamespace
    public class MusicSetting {
        // ReSharper disable InconsistentNaming
        public string alias = string.Empty;
        public MasterAudio.AudioLocation audLocation = MasterAudio.AudioLocation.Clip;
        public AudioClip clip;
        public string songName = string.Empty;
        public string resourceFileName = string.Empty;
        public float volume = 1f;
        public float pitch = 1f;
        public bool isExpanded = true;
        public bool isLoop;

        public MasterAudio.CustomSongStartTimeMode songStartTimeMode = MasterAudio.CustomSongStartTimeMode.Beginning;
        public float customStartTime;
        public float customStartTimeMax;
        public int lastKnownTimePoint = 0;
		public bool wasLastKnownTimePointSet = false;
		public int songIndex = 0;
        public bool songStartedEventExpanded;
        public string songStartedCustomEvent = string.Empty;
        public bool songChangedEventExpanded;
        public string songChangedCustomEvent = string.Empty;

        public MusicSetting() {
            songChangedEventExpanded = false;
        }

        public float SongStartTime {
            get {
                switch (songStartTimeMode) {
                    default:
                    case MasterAudio.CustomSongStartTimeMode.Beginning:
                        return 0f;
                    case MasterAudio.CustomSongStartTimeMode.SpecificTime:
                        return customStartTime;
                    case MasterAudio.CustomSongStartTimeMode.RandomTime:
                        return UnityEngine.Random.Range(customStartTime, customStartTimeMax);
                }
            }
        }

        public static MusicSetting Clone(MusicSetting mus) {
            return new MusicSetting {
                alias = mus.alias,
                audLocation = mus.audLocation,
                clip = mus.clip,
                songName = mus.songName,
                resourceFileName = mus.resourceFileName,
                volume = mus.volume,
                pitch = mus.pitch,
                isExpanded = mus.isExpanded,
                isLoop = mus.isLoop,
                customStartTime = mus.customStartTime,
                songStartedEventExpanded = mus.songStartedEventExpanded,
                songStartedCustomEvent = mus.songStartedCustomEvent,
                songChangedEventExpanded = mus.songChangedEventExpanded,
                songChangedCustomEvent = mus.songChangedCustomEvent
            };
        }
        // ReSharper restore InconsistentNaming
    }
}
/*! \endcond */
