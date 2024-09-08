using UnityEngine;
using UnityEngine.UI;

public class PlatformSpecificImages : MonoBehaviour
{
    public RawImage platformImage;
    public Texture androidTexture;
    public Texture pcTexture;

    void Start()
    {
        #if UNITY_ANDROID
            platformImage.texture = androidTexture;
        #elif UNITY_STANDALONE
            platformImage.texture = pcTexture;
        #endif
    }
}
