using NUnit.Framework;
using UnityEngine;

public class AudioMenuNCredit : MonoBehaviour
{
    // thêm nhạc nền dô menu and credits và cả game nè
    [SerializeField] private AudioSource audioMenuNCredit;
    [SerializeField] private AudioClip menuNCreditClip;
    void Start()
    {
        audioMenuNCredit.clip = menuNCreditClip;
        audioMenuNCredit.Play();
    }

    
}
