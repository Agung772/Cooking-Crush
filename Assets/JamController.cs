using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamController : MonoBehaviour
{
    public float kecepatanJam, penambahanWaktu, time, penguranganWaktu;
    public bool moveJam, penambahanWaktuBool;
    GameController gC;
    public GameObject gameController;
    bool VideoAkhirBool;

    public AudioClip waktu, sepuluhDetik;
    bool cooldownSuaraWaktu, cooldownSuaraWaktu10Detik;
    AudioSource audioSource;
    public void MoveJamTrue()
    {
        moveJam = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        cooldownSuaraWaktu = false;
        cooldownSuaraWaktu10Detik = false;

        penambahanWaktu = 0.5f;
        audioSource = gameObject.GetComponent<AudioSource>();
        gC = gameController.GetComponent<GameController>();
        time = penambahanWaktu;
    }

    // Update is called once per frame
    void Update()
    {
        if (VideoAkhirBool)
        {
            gC.VideoAkhir();
        }

        if (penambahanWaktuBool)
        {
            time -= Time.deltaTime;
            if(time < 0)
            {
                time = penambahanWaktu;
                penambahanWaktuBool = false;
            }
            transform.Rotate(Vector3.forward * 10 * Time.deltaTime * -1);
        }
        else if (moveJam)
        {
            transform.Rotate(Vector3.forward * kecepatanJam * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BatasJam"))
        {
            moveJam = false;
            VideoAkhirBool = true;
            audioSource.Stop();
        }

        if (collision.CompareTag("10detik") && !cooldownSuaraWaktu10Detik)
        {
            audioSource.PlayOneShot(sepuluhDetik);
            cooldownSuaraWaktu10Detik = true;
        }

        if (collision.CompareTag("waktu") && !cooldownSuaraWaktu)
        {
            audioSource.PlayOneShot(waktu);
            cooldownSuaraWaktu = true;
        }
    }


    public void PenguranganWaktu()
    {
        kecepatanJam += penguranganWaktu;
    }
}
