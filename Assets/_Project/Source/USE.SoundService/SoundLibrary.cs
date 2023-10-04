using UnityEngine;

namespace USE.SoundService
{
    [CreateAssetMenu(fileName = ("New SoundLibrary"), menuName = ("Sound/Library"))]
    public class SoundLibrary : ScriptableObject
    {
        [Header("Musics")]
        public AudioClip MainMenuMusic;
    }
}
