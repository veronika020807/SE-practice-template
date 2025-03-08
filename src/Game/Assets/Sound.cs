using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource soundPlay;

    public void PlayThisSound()
    {
        soundPlay.Play();
    }
}
