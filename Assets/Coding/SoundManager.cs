using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip tombol, efekSuaraSenang, efekSuaraBiasa, efekSuaraBuruk;
    public AudioSource aSource;
    
    // Start is called before the first frame update
    void Start()
    {
        aSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EfekSuaraTombol()
    {
        aSource.PlayOneShot(tombol);
    }
}
