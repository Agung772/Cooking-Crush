using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuController : MonoBehaviour
{
    public Button Level1Button, Level2Button, Level3Button, Level4Button, Level5Button;
    public GameObject[] kunciLevel = new GameObject[5];
    public GameObject keteranganUI;
    int levelPassed;
    public TextMeshProUGUI textUI, uangText;
    public string keteranganText;
    public int uang;
    LevelUnlock levelUn2, levelUn3, levelUn4, levelUn5;

    public AudioClip tombol, efekSuaraSenang, efekSuaraBuruk;
    public AudioSource aSource;

    public GameObject videoOpeningPanel, pauseVideoButton, playVideoButton;
    public int videoOpening, videoStory;
    public VideoPlayer videoOpeningVP;
    public float timerVideo;
    public bool videoOpeningBool, matiinTimerOpening;
    // Start is called before the first frame update
    void Start()
    {
        videoStory = PlayerPrefs.GetInt("videoStory");

        if(videoStory == 1)
        {
            PuterUlangVideoOpening();

            videoStory = 0;
            PlayerPrefs.SetInt("videoStory", 0);
        }
        pauseVideoButton.SetActive(true);

        videoOpening = PlayerPrefs.GetInt("videoOpening");

        if (videoOpening == 1)
        {
            videoOpeningBool = false;
            videoOpeningPanel.SetActive(false);
            pauseVideoButton.SetActive(false);
        }
        aSource = gameObject.AddComponent<AudioSource>();

        uang = PlayerPrefs.GetInt("Uang");

        levelUn2 = kunciLevel[2].GetComponent<LevelUnlock>();
        levelUn3 = kunciLevel[3].GetComponent<LevelUnlock>();
        levelUn4 = kunciLevel[4].GetComponent<LevelUnlock>();
        levelUn5 = kunciLevel[5].GetComponent<LevelUnlock>();

        Level2Button.interactable = false;
        Level3Button.interactable = false;
        Level4Button.interactable = false;
        Level5Button.interactable = false;

        RefreshLevel();

    }

    public void PuterUlangVideoOpening()
    {
        Invoke("DelayPuterUlangVideoOpening", 0.5f);
    }
    public void DelayPuterUlangVideoOpening()
    {
        videoOpeningBool = true;
        videoOpeningPanel.SetActive(true);
        pauseVideoButton.SetActive(true);
    }
    private void Update()
    {
        
        if (videoOpeningBool)
        {
            pauseVideoButton.SetActive(true);
            if (!matiinTimerOpening)
            {
                timerVideo -= Time.deltaTime;
            }

            if (timerVideo < 0)
            {
                pauseVideoButton.SetActive(false);
                matiinTimerOpening = true;
                timerVideo = 1;
                videoOpeningPanel.SetActive(false);
                PlayerPrefs.SetInt("videoOpening", 1);
                print("Bisa di save");
                videoOpeningBool = false;
                playVideoButton.SetActive(false);
                pauseVideoButton.SetActive(false);
            }
        }
        uangText.text = ": " + uang;
    }

    public void levelToLoad(int level)
    {
        aSource.PlayOneShot(tombol);
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }

    public void resetPlayerPrefs()
    {
        aSource.PlayOneShot(tombol);
        Level2Button.interactable = false;
        Level3Button.interactable = false;
        Level4Button.interactable = false;
        Level5Button.interactable = false;
        PlayerPrefs.DeleteAll();

    }

    public void Level2Terbuka()
    {
        aSource.PlayOneShot(efekSuaraSenang);
        PlayerPrefs.SetInt("Uang", uang);
        PlayerPrefs.SetInt("LevelPassed", 2);
        print("Level 2 terbuka");
        kunciLevel[2].SetActive(false);
        RefreshLevel();
    }
    public void Level3Terbuka()
    {
        aSource.PlayOneShot(efekSuaraSenang);
        PlayerPrefs.SetInt("Uang", uang);
        PlayerPrefs.SetInt("LevelPassed", 3);
        print("Level 3 terbuka");
        kunciLevel[3].SetActive(false);
        RefreshLevel();
    }
    public void Level4Terbuka()
    {
        aSource.PlayOneShot(efekSuaraSenang);
        PlayerPrefs.SetInt("Uang", uang);
        PlayerPrefs.SetInt("LevelPassed", 4);
        print("Level 4 terbuka");
        kunciLevel[4].SetActive(false);
        RefreshLevel();
    }
    public void Level5Terbuka()
    {
        aSource.PlayOneShot(efekSuaraSenang);
        PlayerPrefs.SetInt("Uang", uang);
        PlayerPrefs.SetInt("LevelPassed", 5);
        print("Level 5 terbuka");
        kunciLevel[5].SetActive(false);
        RefreshLevel();
    }

    public void TrueKeteranganUI()
    {
        aSource.PlayOneShot(tombol);
        keteranganUI.SetActive(true);

        if (levelUn2.level2Bool)
        {
            textUI.text = keteranganText + levelUn2.hargaLevel;
        }
        if (levelUn3.level3Bool)
        {
            textUI.text = keteranganText + levelUn3.hargaLevel;
        }
        if (levelUn4.level4Bool)
        {
            textUI.text = keteranganText + levelUn4.hargaLevel;
        }
        if (levelUn5.level5Bool)
        {
            textUI.text = keteranganText + levelUn5.hargaLevel;
        }

    }

    void RefreshLevel()
    {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");

        switch (levelPassed)
        {
            case 2:
                Level2Button.interactable = true;

                kunciLevel[2].SetActive(false);
                break;
            case 3:
                Level2Button.interactable = true;
                Level3Button.interactable = true;

                kunciLevel[2].SetActive(false);
                kunciLevel[3].SetActive(false);
                break;
            case 4:
                Level2Button.interactable = true;
                Level3Button.interactable = true;
                Level4Button.interactable = true;

                kunciLevel[2].SetActive(false);
                kunciLevel[3].SetActive(false);
                kunciLevel[4].SetActive(false);
                break;
            case 5:
                Level2Button.interactable = true;
                Level3Button.interactable = true;
                Level4Button.interactable = true;
                Level5Button.interactable = true;

                kunciLevel[2].SetActive(false);
                kunciLevel[3].SetActive(false);
                kunciLevel[4].SetActive(false);
                kunciLevel[5].SetActive(false);
                break;

        }
    }

    public void Iya()
    {
        aSource.PlayOneShot(tombol);
        if (levelUn2.level2Bool)
        {

            if (uang > levelUn2.hargaLevel)
            {
                uang -= levelUn2.hargaLevel;
                print("Level terbuka");
                Level2Terbuka();
                keteranganUI.SetActive(false);

            }
            else
            {
                aSource.PlayOneShot(efekSuaraBuruk);
                textUI.text = "Maaf, Uang tidak cukup";
                Invoke("DelayFalseKeteranganUI", 2);
                print("Uang tidak cukup");
            }
            levelUn2.level2Bool = false;
        }

        if (levelUn3.level3Bool)
        {

            if (uang > levelUn3.hargaLevel)
            {
                uang -= levelUn3.hargaLevel;
                print("Level terbuka");
                Level3Terbuka();
                keteranganUI.SetActive(false);

            }
            else
            {
                aSource.PlayOneShot(efekSuaraBuruk);
                textUI.text = "Maaf, Uang tidak cukup";
                Invoke("DelayFalseKeteranganUI", 2);
                print("Uang tidak cukup");
            }
            levelUn3.level3Bool = false;
        }

        if (levelUn4.level4Bool)
        {

            if (uang > levelUn4.hargaLevel)
            {
                uang -= levelUn4.hargaLevel;
                print("Level terbuka");
                Level4Terbuka();
                keteranganUI.SetActive(false);

            }
            else
            {
                aSource.PlayOneShot(efekSuaraBuruk);
                textUI.text = "Maaf, Uang tidak cukup";
                Invoke("DelayFalseKeteranganUI", 2);
                print("Uang tidak cukup");
            }
            levelUn4.level4Bool = false;
        }

        if (levelUn5.level5Bool)
        {

            if (uang > levelUn5.hargaLevel)
            {
                uang -= levelUn5.hargaLevel;
                print("Level terbuka");
                Level5Terbuka();
                keteranganUI.SetActive(false);

            }
            else
            {
                aSource.PlayOneShot(efekSuaraBuruk);
                textUI.text = "Maaf, Uang tidak cukup";
                Invoke("DelayFalseKeteranganUI", 2);
                print("Uang tidak cukup");
            }
            levelUn5.level5Bool = false;
        }
    }
    public void Tidak()
    {
        aSource.PlayOneShot(tombol);
        keteranganUI.SetActive(false);
        levelUn2.level2Bool = false;
        levelUn3.level3Bool = false;
        levelUn4.level4Bool = false;
        levelUn5.level5Bool = false;
    }
    void DelayFalseKeteranganUI()
    {
        keteranganUI.SetActive(false);
    }
    public void SaveUang()
    {
        PlayerPrefs.SetInt("Uang", uang);
    }

    public void PauseVideo()
    {
        videoOpeningVP.Pause();
        playVideoButton.SetActive(true);
        pauseVideoButton.SetActive(false);
        aSource.PlayOneShot(tombol);
        Time.timeScale = 0;

    }

    public void PlayVideo()
    {
        videoOpeningVP.Play();
        playVideoButton.SetActive(false);
        pauseVideoButton.SetActive(true);
        aSource.PlayOneShot(tombol);
        Time.timeScale = 1;

    }

    public void Home()
    {
        SceneManager.LoadScene("HomeScene");
    }


}
